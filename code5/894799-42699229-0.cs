      //FILE: program.cs
      using System;
    
      namespace tcl1
      {
       class Program
       {
         public static void Main(string[] args)
         {
           Console.WriteLine("Hello World!");
    		
           TclInterpreter interp = new TclInterpreter();
    
           //rc == 0 means OK			
           int rc = interp.evalScript("set a 3; expr {$a + 2}");
           Console.WriteLine("rc=" + rc.ToString() 
                                + " Interp.Result = " + interp.Result);
    			
           Console.Write("Press any key to continue . . . ");
           Console.ReadKey(true);
         }//main
       } //class
     }//namespace
    
      //File: tcl_api.cs
      using System.Runtime.InteropServices;
      using System;
    
      namespace tcl1 {
        public class TclAPI {
             [DllImport("tcl86.dLL")]
             public static extern IntPtr Tcl_CreateInterp();
             
             [DllImport("tcl86.dll")]
             public static extern int Tcl_Eval(IntPtr interp,string skript);
             
             [DllImport("tcl86.dll")]
             public static extern IntPtr Tcl_GetObjResult(IntPtr interp);
             
             [DllImport("tcl86.dll")]
             unsafe public static extern char* 
               Tcl_GetStringFromObj(IntPtr tclObj,IntPtr length);
        }
        
        public class TclInterpreter {
            private IntPtr interp;
            
            public TclInterpreter() {
                interp = TclAPI.Tcl_CreateInterp();
                if (interp == IntPtr.Zero) {
                    throw new SystemException("can not initialize Tcl interpreter");
                }
            }
            
            public int evalScript(string script) {
                return TclAPI.Tcl_Eval(interp,script);        
            }
            
            unsafe public string Result {
                get { 
                    IntPtr obj = TclAPI.Tcl_GetObjResult(interp);
                    if (obj == IntPtr.Zero) {
                        return "";
                    } else {
                        return Marshal.PtrToStringAnsi((IntPtr)
                         TclAPI.Tcl_GetStringFromObj(obj,IntPtr.Zero));
                    }
                }
            }
            
        }  
      }
