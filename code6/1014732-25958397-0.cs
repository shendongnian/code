    SaveFileDialog S = new SaveFileDialog();
    if(S.ShowDialog() == DialogResult.OK)
    {
        bool ShowWarning = false;
        string DirPath = System.IO.Path.GetDirectoryName(S.FileName);
        string[] Files = System.IO.Directory.GetFiles(DirPath);
        string NOFWE = DirPath+"\\"+System.IO.Path.GetFileNameWithoutExtension(S.FileName);
        foreach (var item in Files)
        {
    
            if (item.Length > NOFWE.Length && item.Substring(0, NOFWE.Length) == NOFWE)
            {
                int n;
                string Extension = System.IO.Path.GetExtension(item);
                string RemainString = item.Substring(NOFWE.Length, item.Length - Extension.Length - NOFWE.Length);
                bool isNumeric = int.TryParse(RemainString, out n);
                if(isNumeric)
                {
                    ShowWarning = true;
                    break;
                }
                           
            }
        }
        if(ShowWarning)
        {
            if (MessageBox.Show("Warning alert!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Save();//Saving instance
        }
        else
        {
            Save();//Saving instance
        }
    }
