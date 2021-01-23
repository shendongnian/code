        private void ReloadComboBox4()
        {
            comboBox4.Items.Clear()
            string[] filePaths = Directory.GetFiles(@"xml\", "*");
            foreach (string file in filePaths)
            {
                string mypath = file;
                string[] directories = mypath.Split(Path.DirectorySeparatorChar);
                foreach (string dir in directories)
                {
                    comboBox4.Items.Add(dir);
                }
            }
        }
