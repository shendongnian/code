    public static void DoExcel (string FolderPath)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(FolderPath + ".fdf"))
        {
            Thread.Sleep(1000);
            file.Close();
        }
    }
