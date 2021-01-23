    public static void CreatePdf(string action, string file, string directory){
    if (file.EndsWith("xls")){
        Excel.ApplicationClass excel = new Excel.ApplicationClass();
        excel.Visible = false;
        Excel.Workbook workbook = excel.Workbooks.Open(Path.Combine(directory, file),
			Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
        workbook.PrintOut(Type.Missing, Type.Missing, 1, false, Type.Missing, 
			false, Type.Missing, Type.Missing);
        excel.Quit();
    }else{
        Process p = new Process();
                
        p.StartInfo.FileName = file;
        p.StartInfo.Verb = action;
        p.StartInfo.WorkingDirectory = directory;
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        p.StartInfo.CreateNoWindow = true;
        Console.WriteLine("Starting process");
        p.Start();
        //p.Kill();
    }
    Console.WriteLine("Creating Pdf");
    CreatePdf(file);
    }
