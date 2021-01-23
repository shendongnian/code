            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent("FileGroupDescriptor") ? DragDropEffects.All : DragDropEffects.None;
        }
        
        private void lbAttachments_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                try {
                    var dataObject = new OutlookDataObject(e.Data);
                    var filePaths = new StringCollection();
                    string[] fileContentNames = (string[])dataObject.GetData("FileGroupDescriptor");
                    if (fileContentNames.Count() > 0)
                    {
                        var fileStreams = (MemoryStream[])dataObject.GetData("FileContents");
                        for (int fileIndex = 0; fileIndex < fileContentNames.Length; fileIndex++)
                        {
                            var ms = fileStreams[fileIndex];
                            var bytes = ms.ToArray();
                            AddAttachment(fileContentNames[fileIndex], bytes);
                        }
                    }
                }
                catch(Exception) { /* ignore */ }
               
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (s == null)
                    return;
                foreach (string file in s)
                    AddAttachment(file);
            }
