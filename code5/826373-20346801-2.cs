        private void Window_Closing(object sender, CancelEventArgs e)
    {
         MessageBox.Show("File deleted");
        var systemPath = System.Environment.GetFolderPath(
                                  Environment.SpecialFolder.CommonApplicationData);
                var _directoryName1 = Path.Combine(systemPath, "RadiolocationQ");
                var temp_file = Path.Combine(_directoryName1, "temp.ini");
                if (File.Exists(temp1_file))
                {
                    File.Delete(temp1_file);
                }
    }
 
