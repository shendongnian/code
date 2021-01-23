    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ObjectForScripting
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        public object GiveMeAGizmo()
        {
            return new Gizmo();
        }
        public object GiveMeAGizmoUser()
        {
            return new GizmoUser();
        }
    }
