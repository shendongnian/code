    public string Start() 
        {
            if(File.Exists(ResultPath))
            {
              this.Invoke((MethodInvoker)delegate
                    {
                       SaveFileDialog SaveReport = new SaveFileDialog();
                        SaveReport.InitialDirectory = "c:\somepath";
                        SaveReport.CheckPathExists = true;
                        SaveReport.DefaultExt = ".xls";
                        SaveReport.OverwritePrompt = true;
                        SaveReport.ValidateNames = true;
                        if (SaveReport.ShowDialog() == DialogResult.OK)
                        {
                            ResultPath = SaveReport.FileName;
                            if (File.Exists(ResultPath)) File.Delete(ResultPath);
                        }
                    });
            }
        }
