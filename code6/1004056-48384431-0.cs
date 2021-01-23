    private static void ClearVS2013DebugWindow()
        {
            // add reference to "C:\Program Files (x86)\Common Files\microsoft shared\MSEnv\PublicAssemblies\envdte.dll"
            EnvDTE.DTE ide = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
            if (ide != null)
            {
                ide.ExecuteCommand("Edit.ClearOutputWindow", "");
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ide);
            }
        }
