    using System;
    using System.Runtime.InteropServices;
    
    namespace ComLibrary
    {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual),
            Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83B")]
        public interface IComMyReaderInterface
        {
            void MyFunction();
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None), 
            Guid("0D53A3E8-E51A-49C7-944E-E72A2064F9DD"), 
            ProgId("MySimulator.World")]
        [ComDefaultInterface(typeof(IComMyReaderInterface))]
        public class MyReader : IComMyReaderInterface
        {
            public MyReader()
            {
            }
    
            public void MyFunction()
            {
                Console.WriteLine("MyFunction called");
            }
        }
    }
