        OpenFileDialog opFile = new OpenFileDialog();
        opFile.Title = "Select a Image";
        opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
        
        string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProImages\";
        if (Directory.Exists(appPath) == false)
        {
            Directory.CreateDirectory(appPath);
        }
        if (opFile.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string iName = opFile.SafeFileName;
                string filepath = opFile.FileName;
                File.Copy(filepath, appPath + iName);
                picProduct.Image = new Bitmap(opFile.OpenFile());
            }
            catch (Exception exp)
            {
                MessageBox.Show("Unable to open file " + exp.Message);
            }
        }
        else
        {
            opFile.Dispose();
        }
