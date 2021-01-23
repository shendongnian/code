           var divesList = System.IO.DriveInfo.GetDrives()
                                .Where(d => d.DriveType == System.IO.DriveType.Fixed).ToList();
            
            Dictionary<string, string> dictDrives = new Dictionary<string, string>();
            foreach(var item in divesList)
            {
                dictDrives.Add(item.Name, item.Name + " " + item.VolumeLabel);
            }
            cbbFolder.DataSource = new BindingSource(dictDrives, null);
            cbbFolder.DisplayMember = "Value";
