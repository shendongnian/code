    using System;
    using System.Runtime.InteropServices; 
    namespace ConsoleApplication1
    {
        public class CS_Test_Class:IDisposable
        {
            [DllImport("lib.dll")]
            public static extern IntPtr createTestClass();
    
            [DllImport("lib.dll")]
            static private extern void disposeTestClass(IntPtr pTestClassObject);
    
            [DllImport("lib.dll")]
            static private extern void callHello(IntPtr pTestClassObject);
    
            [DllImport("lib.dll")]
            static private extern void callHelloTest1Class(IntPtr pTestClassObject);
    
    
            private IntPtr nativeObject;
    
            public CS_Test_Class()
            {
                this.nativeObject = createTestClass();
            }
    
            public void Dispose()
            {
                Dispose(true);
            }
            protected virtual void Dispose(bool bDisposing)
            {
                disposeTestClass(this.nativeObject);
                this.nativeObject = IntPtr.Zero;
    
                if (bDisposing)
                    GC.SuppressFinalize(this);
            }
    
            ~CS_Test_Class()
            {
                Dispose(false);
            }
    
            public void hello()
            {
                callHello(this.nativeObject);
            }
            public void hello_test1()
            {
                callHelloTest1Class(this.nativeObject);
            }
    
        }
    }
