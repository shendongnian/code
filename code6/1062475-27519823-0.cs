       /// <summary>
       /// This class represents a USB HID (Human Interface Device) device.
       /// </summary>
       public class UsbHidDevice : IDisposable
       {
    
          // The Windows GUID for HID USB devices
          private Guid _deviceClass;
    
          // The full "path name" of the device (set when found)
          private string _devicePath;
    
    
          #region Constructor
    
          public UsbHidDevice()
          {
             // Initialize the Windows GUID for HID devices
             Win32API.HidD_GetHidGuid(out _deviceClass);
          }
    
          #endregion Constructor
    
    
          /// <summary>
          /// Function to search the USB devices to see if the desired one is online.
          /// </summary>
          /// <param name="vendorId">vendor ID, or zero if not significant</param>
          /// <param name="productId">product ID</param>
          public bool FindDevice(int vendorId, int productId)
          {
             string strSearch;
    
             // Build the path search string
             if (vendorId == 0)
                strSearch = string.Format("pid_{0:x4}", productId);
             else
                strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", vendorId, productId);
    
             // Prepare to search the USB device table in Windows
             // This gets a list of all HID devices currently connected to the computer (InfoSet)
             IntPtr hInfoSet = Win32API.SetupDiGetClassDevs(ref _deviceClass, null, IntPtr.Zero, Win32API.DIGCF_DEVICEINTERFACE | Win32API.DIGCF_PRESENT);
    
             try
             {
                // Build up a device interface data block
                Win32API.DeviceInterfaceData oInterface = new Win32API.DeviceInterfaceData();
                oInterface.Size = Marshal.SizeOf(oInterface);
    
                // Now iterate through the InfoSet memory block assigned within Windows in the 
                //  call to SetupDiGetClassDevs to get device details for each device connected
                int nIndex = 0;
    
                // This gets the device interface information for a device at index 'nIndex' in the memory block
                while (Win32API.SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref _deviceClass, (uint)nIndex, ref oInterface))
                {
                   // Get the device path (see helper method 'GetDevicePath')
                   string strDevicePath = GetDevicePath(hInfoSet, ref oInterface);
    
                   // Do a string search, if we find the VID/PID string then we found our device
                   if (!string.IsNullOrEmpty(strDevicePath) && strDevicePath.IndexOf(strSearch) >= 0)
                   {
                      _devicePath = strDevicePath;
                      return true;
                   }
    
                   // If we get here, we didn't find our device. So move on to the next one.
                   log.Debug("FindDevice() - Incorrect device found, keep searching." + strDevicePath);
                   nIndex++;
                }
             }
    
             catch (Exception e)
             {
                log.Error("FindDevice() - Exception:", e);
             }
    
             finally
             {
                // Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
                Win32API.SetupDiDestroyDeviceInfoList(hInfoSet);
             }
    
             // Device not found
             return false;
          }
    
    ... other methods not included here
       }
       /// <summary>
       /// Definition of some Windows API stuff.
       /// 
       /// This is copied from "A USB HID Component for C#" (also called "Sniffer"), By "wimar"
       ///  http://www.codeproject.com/KB/cs/USB_HID.aspx
       /// </summary>
       internal class Win32API
       {
          // Used in SetupDiClassDevs to get devices present in the system
          public const int DIGCF_PRESENT = 0x02;
    
          // Used in SetupDiClassDevs to get device interface details
          public const int DIGCF_DEVICEINTERFACE = 0x10;
    
    
          /// <summary>
          /// Provides details about a single USB device
          /// 
          /// The field "Reserved" has been changed from int to UIntPtr based on information on web page
          /// http://www.codeproject.com/KB/cs/USB_HID.aspx, see message "Does not work on 64 bit Vista?".
          /// </summary>
          [StructLayout(LayoutKind.Sequential, Pack = 1)]
          public struct DeviceInterfaceData
          {
             public int Size;
             public Guid InterfaceClassGuid;
             public int Flags;
             public UIntPtr Reserved;
          }
    
    
          /// <summary>
          /// Gets the GUID that Windows uses to represent HID class devices
          /// </summary>
          /// <param name="gHid">An out parameter to take the Guid</param>
          [DllImport("hid.dll", SetLastError = true)]
          public static extern void HidD_GetHidGuid(out Guid gHid);
          /// <summary>
          /// Allocates an InfoSet memory block within Windows that contains details of devices.
          /// </summary>
          /// <param name="gClass">Class guid (e.g. HID guid)</param>
          /// <param name="strEnumerator">Not used</param>
          /// <param name="hParent">Not used</param>
          /// <param name="nFlags">Type of device details required (DIGCF_ constants)</param>
          /// <returns>A reference to the InfoSet</returns>
          [DllImport("setupapi.dll", SetLastError = true)]
          public static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, [MarshalAs(UnmanagedType.LPStr)] string strEnumerator, IntPtr hParent, uint nFlags);
    
    
          /// <summary>
          /// Gets the DeviceInterfaceData for a device from an InfoSet.
          /// </summary>
          /// <param name="lpDeviceInfoSet">InfoSet to access</param>
          /// <param name="nDeviceInfoData">Not used</param>
          /// <param name="gClass">Device class guid</param>
          /// <param name="nIndex">Index into InfoSet for device</param>
          /// <param name="oInterfaceData">DeviceInterfaceData to fill with data</param>
          /// <returns>True if successful, false if not (e.g. when index is passed end of InfoSet)</returns>
          [DllImport("setupapi.dll", SetLastError = true)]
          public static extern bool SetupDiEnumDeviceInterfaces(IntPtr lpDeviceInfoSet, uint nDeviceInfoData, ref Guid gClass, uint nIndex, ref DeviceInterfaceData oInterfaceData);
    
    
          /// <summary>
          /// Frees InfoSet allocated in call to above.
          /// </summary>
          /// <param name="lpInfoSet">Reference to InfoSet</param>
          /// <returns>true if successful</returns>
          [DllImport("setupapi.dll", SetLastError = true)]
          public static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);
    
    ... other stuff missing
       }
