    private void Rename(string prefix, string filepath, string suffix)
        {            
            //i don't use prefix suffix yet to make sure if my function works
            DirectoryInfo d = new DirectoryInfo(filepath);
            FileInfo[] file = d.GetFiles();
    
            try
            {
                foreach (FileInfo f in file )
            {
                f.MoveTo(@filepath + @"\" + prefix + f.Name.Insert(f.Name.LastIndexOf('.'),suffix));
            }
            }
            catch (Exception e)
            {
                cmd.cetakGagal(e.ToString(), title);
            }
            cmd.cetakSukses("Rename Success", title);
        }
