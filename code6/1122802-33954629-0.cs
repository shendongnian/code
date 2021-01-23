      private void DocumentsDrop(object sender, DragEventArgs e)
      {
        e.Handled = true;
        var point = e.GetPosition(null);
        var dataGridRow = ExtractDataGridRow(point);
        if(dataGridRow !=null)
        {.....
         }
        var droppedItems = e.Data.GetData(DataFormats.FileDrop) as      FileInfo[];
        if (droppedItems != null)
             {
                var droppedDocumentsList = new List<FileInfo>();
                foreach (var droppedItem in droppedItems)
                {
                    if ((droppedItem.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        var directory = new DirectoryInfo(droppedItem.FullName);
                        droppedDocumentsList.AddRange(directory.EnumerateFiles("*", SearchOption.AllDirectories));
                    }
                    else
                    {
                        droppedDocumentsList.Add(droppedItem);
                    }
                }
                if (droppedDocumentsList.Any())
                {
                    ProcessFiles(droppedDocumentsList);
                }
                else
                {
                    DisplayErrorMessage("The selected folder is empty.");
                }
            }
         }
