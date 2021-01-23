    public void OpenPDFFile()
    {
        string file = SetSelectedInfo.Instance.pdfFile;
        System.Diagnostics.Process.Start(Application.dataPath + "/PDFS/" + file);
    }  
