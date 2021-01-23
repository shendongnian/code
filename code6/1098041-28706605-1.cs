            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false;
            string defaultFilename = "Select this folder";
            ofd.FileName = defaultFilename;
            if (ofd.ShowDialog().Value)
            {
                // Check if the user picked a file or a directory, for example:
                if (!ofd.FileName.Contains(defaultFilename))
                {
                    // File code
                }
                else // You should probably turn this into an else if instead
                {
                    // Directory code
                }
                // Alternatively, but still as unsafe
                if (File.Exists(ofd.FileName))
                {
                    // File code
                }
                else
                {
                    // Directory code
                }
            }
