    SqlServerStorage storage = new SqlServerStorage(typeof(ExportarNuevasEmpresas));
    //....
    storage.Progress += storage_Progress;
    
    private void storage_Progress(object sender, ProgressEventArgs e)
    {
        xpProgressBar1.Position = e.Percent;
        xpProgressBar1.Text = "Registro " + e.Percent.ToString();
        Application.DoEvents();
    }
