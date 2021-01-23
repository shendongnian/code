    static void Main(string[] args)
    {
        // this code requires the following COM reference in the project:
        // Microsoft Access 14.0 Object Library
        //
        var objAccess = new Microsoft.Office.Interop.Access.Application();
        objAccess.OpenCurrentDatabase(@"C:\Users\Public\Database1.accdb");
        string formName = "ClientForm";
        objAccess.DoCmd.OpenForm(formName, Microsoft.Office.Interop.Access.AcFormView.acDesign);
        Microsoft.Office.Interop.Access.Form frm = objAccess.Forms[formName];
        Console.WriteLine(String.Format("The FormHeader section of form [{0}] contains the following controls:", formName));
        foreach (Microsoft.Office.Interop.Access.Control ctl in frm.Section["FormHeader"].Controls)
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("    [{0}]", ctl.Name));
            Console.WriteLine(String.Format("        {0}", ctl.GetType()));
        }
        objAccess.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acForm, formName);
        objAccess.CloseCurrentDatabase();
        objAccess.Quit();
        Console.WriteLine();
        Console.WriteLine("Done.");
        Console.ReadKey();
    }
