            // Set up List View
            listViewFiles.View = View.Details;
            listViewFiles.Columns.Clear();
            listViewFiles.Columns.Add("File name");
            listViewFiles.Columns.Add("File path");
            // Populate with files and file paths
            foreach (string filePath in Directory.GetFiles(path, fileType, SearchOption.AllDirectories))
            {
                string fileName = Path.GetFileName(filePath);
                listView1.Items.Add(fileName).SubItems.Add(new FileInfo(fileName).DirectoryName);
            }
