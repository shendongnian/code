    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Text;
    
    public enum TouchDeviceKind { Mouse, Pen, Touch }
    
    public class TouchTabletCollection {
        public TouchTabletCollection() {
            Guid CLSID_TabletManager = new Guid("A5B020FD-E04B-4e67-B65A-E7DEED25B2CF");
            var manager = (ITabletManager)Activator.CreateInstance(Type.GetTypeFromCLSID(CLSID_TabletManager));
            int count = 0;
            manager.GetTabletCount(out count);
            Count = count;
            tablets = new List<TouchTablet>(count);
            for (int index = 0; index < count; index++) {
                tablets.Add(new TouchTablet(manager, index));
            }
        }
        public int Count { get; private set; }
        public TouchTablet this[int index] {
            get { return tablets[index]; }
        }
        private List<TouchTablet> tablets;
    }
    
    public class TouchTablet {
        internal TouchTablet(ITabletManager mgr, int index) {
            ITablet itf;
            mgr.GetTablet(index, out itf);
            device1 = itf;
            device2 = (ITablet2)itf;
            device3 = (ITablet3)itf;
        }
        public bool IsMultiTouch {
            get {
                bool multi;
                device3.IsMultiTouch(out multi);
                return multi;
            }
        }
        public TouchDeviceKind Kind {
            get {
                TouchDeviceKind kind;
                device2.GetDeviceKind(out kind);
                return kind;
            }
        }
        public string Name {
            get {
                IntPtr pname;
                device1.GetName(out pname);
                return Marshal.PtrToStringUni(pname);
            }
        }
        public Rectangle InputRectangle {
            get {
                RECT rc;
                device1.GetMaxInputRect(out rc);
                return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom);
            }
        }
        public Rectangle ScreenRectangle {
            get {
                RECT rc;
                device2.GetMatchingScreenRect(out rc);
                return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom);
            }
        }
        private ITablet device1;
        private ITablet2 device2;
        private ITablet3 device3;
    }
    
    // COM declarations
    [ComImport, Guid("764DE8AA-1867-47C1-8F6A-122445ABD89A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITabletManager {
        void GetDefaultTablet(out ITablet table);
        void GetTabletCount(out int count);
        void GetTablet(int index, out ITablet tablet);
        // rest omitted...
    }
    [ComImport, Guid("1CB2EFC3-ABC7-4172-8FCB-3BC9CB93E29F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITablet {
        void Dummy1();
        void Dummy2();
        void GetName(out IntPtr pname);
        void GetMaxInputRect(out RECT inputRect);
        void GetHardwareCaps(out uint caps);
        // rest omitted
    }
    [ComImport, Guid("C247F616-BBEB-406A-AED3-F75E656599AE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITablet2 {
        void GetDeviceKind(out TouchDeviceKind kind);
        void GetMatchingScreenRect(out RECT rect);
    }
    [ComImport, Guid("AC0E3951-0A2F-448E-88D0-49DA0C453460")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITablet3 {
        void IsMultiTouch(out bool multi);
        void GetMaximumCursors(out int cursors);
    }
    
    internal struct RECT { public int Left, Top, Right, Bottom; }
