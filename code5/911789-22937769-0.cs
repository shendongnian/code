    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    xlApp.Visible = true;
    Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    
    VBProject vbProj = wb.VBProject; // access to VBAProject
    VBComponent vbComp = vbProj.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule); // adding a standard coding module
    vbComp.CodeModule.DeleteLines(1, vbComp.CodeModule.CountOfLines); //emptying it
    
    // this is VBA code to add to the coding module
    string code = "Public Sub HelloWorld() \n" +
                    "    MsgBox \"hello world!\" \n" +
                    "End Sub";
    
    // code should be added to the module now
    vbComp.CodeModule.AddFromString(code); 
    
    // location to which you want to save the workbook - desktop in this case
    string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\macroWorkbook.xlsm";
    
    // run the macro
    xlApp.Run("HelloWorld");
     
    // save as macro enabled workbook
    wb.SaveAs(Filename: fullPath, FileFormat: XlFileFormat.xlOpenXMLWorkbookMacroEnabled);
    xlApp.Quit();
