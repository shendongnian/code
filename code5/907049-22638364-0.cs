        public void UpdateDialog(int percentComplete = 0, string fileName = "", int numFiles = 0, TimeSpan? processTime = null)
        {
            if (InvokeRequired)
            {
                Invoke(new System.Windows.Forms.MethodInvoker(() => UpdateDialog(percentComplete, fileName, numFiles, processTime)));
            }
            ...
            if (numFiles > 0)
            {
                labelNumFiles.Text = Convert.ToString(numFiles);
            }
            if (!processTime.Equals(null))
            {
                labelProcessTime.Text = Convert.ToString(processTime);
            }
        }
