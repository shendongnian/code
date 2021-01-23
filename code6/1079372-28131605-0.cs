    using System;
    using Shell32;
    
    namespace SO28073584
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sh = (IShellDispatch4)Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
                var tempFiles = sh.NameSpace(Shell32.ShellSpecialFolderConstants.ssfINTERNETCACHE);
                foreach ( Shell32.FolderItem item in tempFiles.Items() )
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
