    void addModule()
    {
        VBProject vbProj = Globals.ThisWorkbook.VBProject as VBProject;
        VBComponent vbComp = 
                     vbProj.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
        vbComp.CodeModule.DeleteLines(1, vbComp.CodeModule.CountOfLines);
    
        string code = "Public Sub CentreText() \n" + 
                      "    activeCell.HorizontalAlignment = xlCenter \n" +
                      "End Sub";
    
        vbComp.CodeModule.AddFromString(code);
    }
