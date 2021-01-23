    object saveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdSaveChanges;
    newApp.Quit(ref saveChanges, ref Unknown, ref Unknown);
    Marshal.ReleaseComObject(newApp);
    using (StreamReader sr = new StreamReader((string)Target))
    {
        Console.WriteLine(sr.ReadToEnd());
    }
