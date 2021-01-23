    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("{7447EEEA-3D48-4D20-80DF-739413718794}")]
    public interface IFoo {
        [DispId(42)] void method();
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("{40815257-BFD2-43D9-9CF8-FB27CC884C71}")]
    [ProgId("Acme.Foo")]
    public class Foo : IFoo {
        public void method() { /* etc */ }
    }
