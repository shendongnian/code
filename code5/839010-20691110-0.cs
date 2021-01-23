        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveDlg = new Microsoft.Win32.SaveFileDialog();
            saveDlg.DefaultExt = ".rtf";
            saveDlg.Filter = "RTF Documents (.rtf)|*rtf";
            Nullable<bool> rezultat = saveDlg.ShowDialog();
            if (rezultat == true)
            {
                string filename = saveDlg.FileName;
                System.IO.File.Create(filename);
            }
            else
            {
                this.Close();
            }
        }
