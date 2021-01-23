        private void WarnUserIfTempFolderFull()
        {
            string tempFile = null;
            try
            {
                tempFile = Path.GetTempFileName();
            }
            catch (IOException e)
            {
                string problem = "The Temporary Folder is full.";
                string message = "{ProductName} has detected that the Windows Temporary Folder is full. \n" + 
                                 "This may prevent the {ProductName} from functioning correctly.\n" + 
                                 "Please delete old files in your temporary folder (%TEMP%) and try again.";
                Logger.Warn(problem);
                MessageBox.Show(message, caption: problem);
            }
            finally
            {
                if (tempFile != null) File.Delete(tempFile);
            }
        }
