        private void lvDataBinding_DragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
        private void lvDataBinding_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                String[] files =  e.Data.GetData(DataFormats.FileDrop) as String[];
                // that version only supports drop of a file, but could be augmented
                FileInfo fileInfo = new FileInfo(files[0]);
                sourceFileData = new FileData { DateCreated = fileInfo.CreationTime, Name = fileInfo.FullName };
                e.Handled = true;
            }
        }
