    private void button1_Click(object sender, System.EventArgs e)
    {
             Excel.Application oExcel;
             Excel.Workbook oBook;
             VBIDE.VBComponent oModule;
             Office.CommandBar oCommandBar;
             Office.CommandBarButton oCommandBarButton;
             String sCode;
             Object oMissing = System.Reflection.Missing.Value;
             // Create an instance of Excel.
             oExcel = new Excel.Application();
             // Add a workbook.
             oBook = oExcel.Workbooks.Add(@"C:\Users\user\Downloads\test.xlsm");
             // Create a new VBA code module.
             oModule = oBook.VBProject.VBComponents.Add(VBIDE.vbext_ComponentType.vbext_ct_StdModule);
         
             sCode =
             //paste in your macro here, with each line followed by a new line
             "Sub TestMacro()\r\n" +
             "Columns(\"D:D\").Select\r\n" +
             "Selection.Copy\r\n" +
             "Columns(\"F:F\").Select\r\n" +
             "ActiveSheet.Paste\r\n" +
             "Application.CutCopyMode = False\r\n" +
             "ActiveSheet.Range(\"$F$1:$F$542\").RemoveDuplicates Columns:=1, Header:=xlNo\r\n" +
             "Range(\"F1\").Select\r\n" +
             "ActiveCell.FormulaR1C1 = \"Unique Query\"\r\n" +
             "Range(\"F2\").Select\r\n" +
             "End Sub";
             // Add the VBA macro to the new code module.
             oModule.CodeModule.AddFromString(sCode);
             
             // Make Excel visible to the user.
             oExcel.Visible = true;
             // Set the UserControl property so Excel won't shut down.
             oExcel.UserControl = true;
             // Release the variables.
             oModule = null;
             oBook = null;
             oExcel = null;             
             // Collect garbage.
             GC.Collect();
    }
