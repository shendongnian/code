    for (int i = 1; i < 11; i++)
    {
        string tmp =  destDirName + "\\Device\\ " + i.ToString();
        if ( ! Directory.Exists(tmp)) 
        {
             Directory.CreateDirectory(tmp);
             break;
        }
    }
