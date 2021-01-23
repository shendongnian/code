    private void checkAndMakeFiles()
        {
            foreach (FileInfo fI in this.files)
            {
                    if (!fI.Exists)
                    {
                        fI.Create();
                        fI.Close();
                    }
              }
        }
