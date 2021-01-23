    namespace DeviceEnumerator
    {
        public class Program
        {
            public static void Main()
            {
                var deviceTree = new DeviceTree();
     
                foreach (var deviceClass in Win32.DeviceClasses)
                {
                    Console.WriteLine("\n{0}:", deviceClass.Value);
     
                    foreach (var device in deviceTree.DeviceNodes
                        .Where(d => d.ClassGuid == deviceClass.Key))
                    {
                        Console.WriteLine(
                            "\t{1}: {0}",
                            device.Description,
                            device.EnumeratorName);
                    }
                }
     
                Console.Write("\n\nAny key...");
                Console.ReadKey();
            }
        }
     
        public class DeviceTree : IDisposable
        {
            private IntPtr _machineHandle = IntPtr.Zero;
            private IntPtr _rootDeviceHandle = IntPtr.Zero;
            private DeviceNode _rootNode;
     
            // flat collection of all devices found
            private List< DeviceNode > _deviceNodes;
     
            public DeviceNode RootNode
            {
                get
                {
                    return this._rootNode;
                }
            }
     
            public List< DeviceNode > DeviceNodes
            {
                get
                {
                    return this._deviceNodes;
                }
            }
     
            public DeviceTree()
            {
                EnumerateDevices();
            }
     
            ~DeviceTree()
            {
                this.Dispose(false);
            }
     
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
     
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this._deviceNodes.Clear();
                }
     
                this.DisconnectFromMachine();
            }
     
            private void EnumerateDevices()
            {
                this.DisconnectFromMachine();
     
                // local machine assumed
                if (Win32.CM_Connect_Machine(
                    null, ref this._machineHandle) != 0)
                {
                    return;
                }
     
                try
                {
                    Win32.CM_Locate_DevNode_Ex(
                        ref this._rootDeviceHandle,
                        0,
                        0,
                        this._machineHandle);
     
                    // recursive enumeration
                    this._rootNode = new DeviceNode(
                        this._rootDeviceHandle,
                        null,
                        this._machineHandle);
                }
                finally
                {
                    this.DisconnectFromMachine();
     
                    if (this._rootNode != null)
                    {
                        this._deviceNodes = this._rootNode
                            .Flatten(node => node.Children).ToList();
                    }
                }
            }
     
            private void DisconnectFromMachine()
            {
                if (this._machineHandle != IntPtr.Zero)
                {
                    Win32.CM_Disconnect_Machine(this._machineHandle);
                    this._machineHandle = IntPtr.Zero;
                }
            }
        }
     
        public class DeviceNode : IDisposable
        {
            private readonly DeviceNode _parentDevice;
            private readonly List< DeviceNode > _children;
            private readonly IntPtr _deviceHandle;
            private readonly IntPtr _machineHandle;
     
            private readonly Dictionary< int, string >
                _deviceProperties;
     
            public DeviceNode ParentDevice
            {
                get
                {
                    return _parentDevice;
                }
            }
     
            public Dictionary< int, string > DeviceProperties
            {
                get
                {
                    return _deviceProperties;
                }
            }
     
            public List< DeviceNode > Children
            {
                get
                {
                    return this._children;
                }
            }
     
            public Guid ClassGuid
            {
                get
                {
                    string buffer =
                        this.GetProperty(Win32.DevRegProperty.ClassGuid);
     
                    var guid = new Guid();
     
                    if (buffer.Length >= 32)
                    {
                        try
                        {
                            guid = new Guid(buffer);
                        }
                        catch
                        {
                            guid = new Guid();
                        }
                    }
     
                    return guid;
                }
            }
     
            public string Description
            {
                get
                {
                    return
                        GetProperty(Win32.DevRegProperty.DeviceDescription);
                }
            }
     
            public string FriendlyName
            {
                get
                {
                    return
                        GetProperty(Win32.DevRegProperty.FriendlyName);
                }
            }
     
            public string EnumeratorName
            {
                get
                {
                    return
                        GetProperty(Win32.DevRegProperty.EnumeratorName);
                }
            }
     
            public string LocationInfo
            {
                get
                {
                    return
                        GetProperty(Win32.DevRegProperty.LocationInfo);
                }
            }
     
            public DeviceNode(IntPtr deviceHandle, DeviceNode parentDevice)
                : this(
                        deviceHandle, 
                        parentDevice, 
                        parentDevice._machineHandle)
            {
            }
     
            public DeviceNode(
                IntPtr deviceHandle,
                DeviceNode parentDevice,
                IntPtr machineHandle)
            {
                _deviceProperties = new Dictionary< int, string >();
                _children = new List< DeviceNode >();
     
                _deviceHandle = deviceHandle;
                _machineHandle = machineHandle;
                _parentDevice = parentDevice;
     
                EnumerateDeviceProperties();
                EnumerateChildren();
            }
     
            private string GetProperty(
                Win32.DevRegProperty devRegProperty)
            {
                return GetProperty((int)devRegProperty);
            }
     
            private string GetProperty(int index)
            {
                string buffer;
                var result = this._deviceProperties
                    .TryGetValue(index, out buffer);
                return result ? buffer : string.Empty;
            }
     
            private void EnumerateDeviceProperties()
            {
                for (var index = 0; index < 64; index++)
                {
                    uint bufsize = 2048;
     
                    IntPtr buffer = 
                        Marshal.AllocHGlobal((int)bufsize);
     
                    var result = 
                        Win32.CM_Get_DevNode_Registry_Property_Ex(
                            _deviceHandle,
                            index,
                            IntPtr.Zero,
                            buffer,
                            ref bufsize,
                            0,
                            _machineHandle);
     
                    var propertyString = result == 0
                        ? Marshal.PtrToStringAnsi(buffer) 
                        : string.Empty;
     
                    _deviceProperties.Add(index, propertyString);
     
                    Marshal.FreeHGlobal(buffer);
                }
            }
     
            private void EnumerateChildren()
            {
                IntPtr ptrFirstChild = IntPtr.Zero;
     
                if (Win32.CM_Get_Child_Ex(
                    ref ptrFirstChild, 
                    _deviceHandle, 
                    0, 
                    _machineHandle) != 0)
                {
                    return;
                }
     
                var ptrChild = ptrFirstChild;
                var ptrSibling = IntPtr.Zero;
     
                do
                {
                    var childDevice = new DeviceNode(ptrChild, this);
                    _children.Add(childDevice);
     
                    if (Win32.CM_Get_Sibling_Ex(
                        ref ptrSibling, 
                        ptrChild, 
                        0, 
                        _machineHandle) != 0) break;
     
                    ptrChild = ptrSibling;
                }
                while (true);
            }
     
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
     
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _deviceProperties.Clear();
                }
            }
        }
     
        internal static class LinqExtensionMethods
        {
            public static IEnumerable< T > Return< T >(T element)
            {
                yield return element;
            }
     
            public static IEnumerable< T > StartWith< T >(
                this IEnumerable< T > list, T element)
            {
                return Return(element).Concat(list);
            }
     
            public static IEnumerable< TEntity > Flatten< TEntity >(
                this TEntity element,
                Func< TEntity, IEnumerable< TEntity > > childSelector)
            {
                if (childSelector(element) != null)
                    return childSelector(element)
                        .SelectMany(child => child.Flatten(childSelector))
                        .StartWith(element);
     
                var items = new List< TEntity > { element };
                return items;
            }
        }
     
        public static class Win32
        {
            // this is a partial list
            public static readonly
                Dictionary< Guid, string > DeviceClasses =
                new Dictionary< Guid, string >
                {
                    { new Guid("{4d36e967-e325-11ce-bfc1-08002be10318}"), 
                        "Disk Drives" },
                    { new Guid("{4d36e968-e325-11ce-bfc1-08002be10318}"), 
                        "Display Adapters" },
                    { new Guid("{4d36e96b-e325-11ce-bfc1-08002be10318}"), 
                        "Keyboards" },
                    { new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}"), 
                        "Mice" },
                };
     
            public enum DevRegProperty : uint
            {
                DeviceDescription = 1,
                HardwareId = 2,
                CompatibleIds = 3,
                Unused0 = 4,
                Service = 5,
                Unused1 = 6,
                Unused2 = 7,
                Class = 8,
                ClassGuid = 9,
                Driver = 0x0a,
                ConfigFlags = 0x0b,
                Mfg = 0x0c,
                FriendlyName = 0x0d,
                LocationInfo = 0x0e,
                PhysicalDeviceObjectName = 0x0f,
                Capabilities = 0x10,
                UiNumber = 0x11,
                UpperFilters = 0x12,
                LowerFilters = 0x13,
                BusTypeGuid = 0x014,
                LegacyBusType = 0x15,
                BusNumber = 0x16,
                EnumeratorName = 0x17,
            }
     
            [DllImport("kernel32.dll")]
            public static extern uint GetLogicalDrives();
     
            [DllImport("kernel32.dll")]
            public static extern int GetDriveType(
                [MarshalAs(UnmanagedType.LPStr)] string rootPathName);
     
            [DllImport("cfgmgr32.dll")]
            public static extern int CM_Connect_Machine(
                [MarshalAs(UnmanagedType.LPStr)] string uncServerName,
                ref IntPtr machineHandle);
     
            [DllImport("cfgmgr32.dll")]
            public static extern int CM_Disconnect_Machine(
                IntPtr machineHandle);
     
            [DllImport("cfgmgr32.dll")]
            public static extern int CM_Locate_DevNode_Ex(
                ref IntPtr deviceHandle,
                int deviceId,
                uint flags,
                IntPtr machineHandle);
     
            [DllImport("cfgmgr32.dll")]
            public static extern int CM_Get_Child_Ex(
                ref IntPtr childDeviceHandle,
                IntPtr parentDeviceHandle,
                uint flags,
                IntPtr machineHandle);
     
            [DllImport("cfgmgr32.dll")]
            public static extern int CM_Get_Sibling_Ex(
                ref IntPtr siblingDeviceHandle,
                IntPtr deviceHandle,
                uint flags,
                IntPtr machineHandle);
     
            [DllImport("cfgmgr32.dll")]
            public static extern int 
                CM_Get_DevNode_Registry_Property_Ex(
                    IntPtr deviceHandle,
                    int property,
                    IntPtr regDataType,
                    IntPtr outBuffer,
                    ref uint size,
                    int flags,
                    IntPtr machineHandle);
        }
    }
