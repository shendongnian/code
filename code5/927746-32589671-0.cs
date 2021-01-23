    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.ServiceProcess;
    namespace ServiceManager
    {
        /// <summary>
        /// Extensions to the ServiceController class.
        /// </summary>
        public static class ServiceControlerExtensions
        {
            /// <summary>
            /// Set the start mode for the service.
            /// </summary>
            /// <param name="serviceController">The service controller.</param>
            /// <param name="mode">The desired start mode.</param>
            public static void SetStartMode(this ServiceController serviceController, ServiceStartModeEx mode)
            {
                IntPtr serviceManagerHandle = OpenServiceManagerHandle();
                IntPtr serviceHandle = OpenServiceHandle(serviceController, serviceManagerHandle);
                try
                {
                    if (mode == ServiceStartModeEx.DelayedAutomatic)
                    {
                        ChangeServiceStartType(serviceHandle, ServiceStartModeEx.Automatic);
                        ChangeDelayedAutoStart(serviceHandle, true);
                    }
                    else
                    {
                        // Delayed auto-start overrides other settings, so it must be set first.
                        ChangeDelayedAutoStart(serviceHandle, false);
                        ChangeServiceStartType(serviceHandle, mode);
                    }
                }
                finally
                {
                    if (serviceHandle != IntPtr.Zero)
                    {
                        CloseServiceHandle(serviceHandle);
                    }
                    if (serviceHandle != IntPtr.Zero)
                    {
                        CloseServiceHandle(serviceManagerHandle);
                    }
                }
            }
            private static IntPtr OpenServiceHandle(ServiceController serviceController, IntPtr serviceManagerHandle)
            {
                var serviceHandle = OpenService(
                                                serviceManagerHandle,
                                                serviceController.ServiceName,
                                                SERVICE_QUERY_CONFIG | SERVICE_CHANGE_CONFIG);
                if (serviceHandle == IntPtr.Zero)
                {
                    throw new ExternalException("Open Service Error");
                }
                return serviceHandle;
            }
            private static IntPtr OpenServiceManagerHandle()
            {
                IntPtr serviceManagerHandle = OpenSCManager(null, null, SC_MANAGER_ALL_ACCESS);
                if (serviceManagerHandle == IntPtr.Zero)
                {
                    throw new ExternalException("Open Service Manager Error");
                }
                return serviceManagerHandle;
            }
            private static void ChangeServiceStartType(IntPtr serviceHandle, ServiceStartModeEx mode)
            {
                bool result = ChangeServiceConfig(
                                                 serviceHandle,
                                                 SERVICE_NO_CHANGE,
                                                 (uint)mode,
                                                 SERVICE_NO_CHANGE,
                                                 null,
                                                 null,
                                                 IntPtr.Zero,
                                                 null,
                                                 null,
                                                 null,
                                                 null);
                if (result == false)
                {
                    ThrowLastWin32Error("Could not change service start type");
                }
            }
            private static void ChangeDelayedAutoStart(IntPtr hService, bool delayed)
            {
                // Create structure that contains DelayedAutoStart property.
                SERVICE_DELAYED_AUTO_START_INFO info = new SERVICE_DELAYED_AUTO_START_INFO();
                // Set the DelayedAutostart property in that structure.
                info.fDelayedAutostart = delayed;
                // Allocate necessary memory.
                IntPtr hInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SERVICE_DELAYED_AUTO_START_INFO)));
                // Convert structure to pointer.
                Marshal.StructureToPtr(info, hInfo, true);
                // Change the configuration.
                bool result = ChangeServiceConfig2(hService, SERVICE_CONFIG_DELAYED_AUTO_START_INFO, hInfo);
                // Release memory.
                Marshal.FreeHGlobal(hInfo);
                if (result == false)
                {
                    ThrowLastWin32Error("Could not set service to delayed automatic");
                }
            }
            private static void ThrowLastWin32Error(string messagePrefix)
            {
                int nError = Marshal.GetLastWin32Error();
                var win32Exception = new Win32Exception(nError);
                string message = string.Format("{0}: {1}", messagePrefix, win32Exception.Message);
                throw new ExternalException(message);
            }
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern IntPtr OpenService(
                IntPtr hSCManager,
                string lpServiceName,
                uint dwDesiredAccess);
            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode,
                SetLastError = true)]
            private static extern IntPtr OpenSCManager(
                string machineName,
                string databaseName,
                uint dwAccess);
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern Boolean ChangeServiceConfig(
                IntPtr hService,
                UInt32 nServiceType,
                UInt32 nStartType,
                UInt32 nErrorControl,
                String lpBinaryPathName,
                String lpLoadOrderGroup,
                IntPtr lpdwTagId,
                [In] char[] lpDependencies,
                String lpServiceStartName,
                String lpPassword,
                String lpDisplayName);
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool ChangeServiceConfig2(
                IntPtr hService,
                int dwInfoLevel,
                IntPtr lpInfo);
            [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
            private static extern int CloseServiceHandle(IntPtr hSCObject);
            private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
            private const uint SERVICE_QUERY_CONFIG = 0x00000001;
            private const uint SERVICE_CHANGE_CONFIG = 0x00000002;
            private const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;
            private const int SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 3;
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            private struct SERVICE_DELAYED_AUTO_START_INFO
            {
                public bool fDelayedAutostart;
            }
        }
    }
    namespace ServiceManager
    {
        public enum ServiceStartModeEx
        {
            Automatic = 2,
            Manual = 3,
            Disabled = 4,
            DelayedAutomatic = 99
        }
    }
