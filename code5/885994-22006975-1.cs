    private bool Bad_File_Testing(string file_test)
    {    
        try
        {
            Image radar = Bitmap.FromFile(file_test); // argument value used
            radar.Dispose();
            return true;     
        }
        catch
        {
            Logger.Write("Last radar image was damaged and have been deleted");
            return false; 
        }
    }
