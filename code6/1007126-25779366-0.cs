    using EnvDTE;
    using EnvDTE80;
    using System;
    
    public class C : VisualCommanderExt.ICommand
    {
        public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
        {
            EnvDTE.TextSelection ts = DTE.ActiveWindow.Selection as EnvDTE.TextSelection;
            if (ts == null)
                throw new Exception("No Selection");
        
            EnvDTE.CodeParameter codeParam = ts.ActivePoint.CodeElement[vsCMElement.vsCMElementParameter] as EnvDTE.CodeParameter;
            if (codeParam == null)
                throw new Exception("Not Parameter");
        
            System.Type tClass = GetTypeByName(DTE, package, codeParam.Type.AsFullName);
            string properties = "";
            foreach (var p in tClass.GetProperties())
            {
                properties += codeParam.Name + "." + p.Name + System.Environment.NewLine;
            }
    
            // Move into the method and dump the properties there
            ts.LineDown();
            ts.LineDown();
            ts.StartOfLine();
            ts.Insert(properties);
        }
    
        private System.Type GetTypeByName(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package, string name)
        {
            System.IServiceProvider serviceProvider = package as System.IServiceProvider;
            Microsoft.VisualStudio.Shell.Design.DynamicTypeService typeService = 
                serviceProvider.GetService(typeof(Microsoft.VisualStudio.Shell.Design.DynamicTypeService)) as
                    Microsoft.VisualStudio.Shell.Design.DynamicTypeService;
    
            Microsoft.VisualStudio.Shell.Interop.IVsSolution sln = serviceProvider.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.IVsSolution)) as
                Microsoft.VisualStudio.Shell.Interop.IVsSolution;
    
            Microsoft.VisualStudio.Shell.Interop.IVsHierarchy hier;
            sln.GetProjectOfUniqueName(DTE.ActiveDocument.ProjectItem.ContainingProject.UniqueName, out hier);
        
            return typeService.GetTypeResolutionService(hier).GetType(name, true);
        }
    }
