    public static void CopyBack(string strFileName)
    {
        string strSavePath = GetSavePath();
        strSavePath = System.IO.Path.Combine(strSavePath, System.IO.Path.GetFileName(strFileName));
        if (System.IO.File.Exists(strSavePath))
        {
            System.IO.File.Copy(strSavePath, strFileName, true); // Exception - Unauthorized access
        }
    }
