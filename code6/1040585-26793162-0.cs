    private void button1_Click(object sender, EventArgs e)
        {
            this.CopyAll(new DirectoryInfo(@"D:\Original"), new DirectoryInfo(@"D:\Copy"));
        }
        private void CopyAll(DirectoryInfo oOriginal, DirectoryInfo oFinal)
        {
            foreach (DirectoryInfo oFolder in oOriginal.GetDirectories())
                this.CopyAll(oFolder, oFinal.CreateSubdirectory(oFolder.Name));
            foreach (FileInfo oFile in oOriginal.GetFiles())
                oFile.CopyTo(oFinal.FullName + @"\" + oFile.Name, true);
        }
