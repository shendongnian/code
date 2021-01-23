    using (FileStream fs = new FileStream("c:\\files.txt", FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach (string item in lstFilesFound.Items)
            {
                sw.WriteLine(item);
            }
        }
    }
