    private void button1_Click(object sender, EventArgs e)
    {
        // test data
        int recordIdToUpdate = 15;
        string bmpPath = @"C:\Users\Gord\Pictures\bmpMe.bmp";
        var paths = new System.Collections.Specialized.StringCollection();
        paths.Add(bmpPath);
        Clipboard.SetFileDropList(paths);
        // COM Reference required:
        //     Microsoft Access 14.0 Object Library
        var accApp = new Microsoft.Office.Interop.Access.Application();
        accApp.OpenCurrentDatabase(@"C:\Users\Public\Database1.accdb");
        accApp.DoCmd.OpenForm(
                "PhotoForm",
                Microsoft.Office.Interop.Access.AcFormView.acNormal, 
                null,
                "ID=" + recordIdToUpdate);
        accApp.DoCmd.RunCommand(Microsoft.Office.Interop.Access.AcCommand.acCmdPaste);
        accApp.DoCmd.Close(
                Microsoft.Office.Interop.Access.AcObjectType.acForm, 
                "PhotoForm", 
                Microsoft.Office.Interop.Access.AcCloseSave.acSaveNo);
        accApp.CloseCurrentDatabase();
        accApp.Quit();
        this.Close();
    }
