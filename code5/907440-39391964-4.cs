    private bool RemoveFileFromServer(string path)
    {
        var fullPath = Request.MapPath(path);
        if (!System.IO.File.Exists(fullPath)) return false;
    
        try //Maybe error could happen like Access denied or Presses Already User used
        {
            System.IO.File.Delete(fullPath);
            return true;
        }
        catch (Exception e)
        { 
            //Debug.WriteLine(e.Message);
        }
        return false;
    }
