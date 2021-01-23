    $TypeDefinition=@"
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    namespace shell32 {
    
        //Put all the variables required for the DLLImports here
        enum RecycleFlags : uint { SHERB_NOCONFIRMATION = 0x00000001, SHERB_NOPROGRESSUI = 0x00000002, SHERB_NOSOUND = 0x00000004 }
        public static class RecycleBin {
            [DllImport("Shell32.dll",CharSet=CharSet.Unicode)]
                internal static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        }
        public class ShellWrapper : IDisposable {
            // Creates a new wrapper for the local machine
            public ShellWrapper() { }
            // Disposes of this wrapper
            public void Dispose() {
                GC.SuppressFinalize(this);
            }
            //Put public function here
            public uint Empty() {
                uint ret = RecycleBin.SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI | RecycleFlags.SHERB_NOSOUND);
                return ret;
            }
            // Occurs on destruction of the Wrapper
            ~ShellWrapper() {
                Dispose();
            }
        } //Wrapper class
    }
    "@
    Add-Type -TypeDefinition $TypeDefinition -PassThru | out-null
    $RecycleBin=new-object Shell32.ShellWrapper
    $RecycleBin.Empty()
