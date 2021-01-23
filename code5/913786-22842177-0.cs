    protected string File_Upload()
    {
            string strFilename;
            strFilename = File1.PostedFile.FileName;
            strFilename = System.IO.Path.GetFileName(strFilename);
            File1.PostedFile.SaveAs(@"E:\" + strFilename); /*saves the uploaded file in the specified directory */
            return @"E:\" + strFilename; // <--- Change is here
    
    }
