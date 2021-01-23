        private FileData sourceFileData;
        private void ListBoxItemPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            var listboxItem = sender as ListBoxItem;
            if (listboxItem == null)
                return;
            sourceFileData = listboxItem.DataContext as FileData;
            if (sourceFileData == null)
                return;
            var data = new DataObject();
            data.SetData(sourceFileData);
            // provide some data for DnD in other applications (Word, ...)
            data.SetData(DataFormats.StringFormat, sourceFileData.ToString());
            DragDropEffects effect = DragDrop.DoDragDrop(listboxItem, data, DragDropEffects.Move | DragDropEffects.Copy);
        }
        private void ListBoxItemDrop(object sender, DragEventArgs e)
        {
            // support application data source and explorer file
            if (!e.Data.GetDataPresent(typeof(FileData)) && !e.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            var listBoxItem = sender as ListBoxItem;
            if (listBoxItem == null)
                return;
            var targetFile = listBoxItem.DataContext as FileData;
            if (targetFile != null)
            {
                int targetIndex = files.IndexOf(targetFile);
                int sourceIndex = files.IndexOf(sourceFileData);
                double y = e.GetPosition(listBoxItem).Y;
                bool insertAfter = y > listBoxItem.ActualHeight / 2;
                if (insertAfter)
                {
                    targetIndex++;
                }
                if (sourceIndex > targetIndex)
                {
                    if (sourceIndex != -1)
                        files.RemoveAt(sourceIndex);
                    files.Insert(targetIndex, sourceFileData);
                }
                else
                {
                    files.Insert(targetIndex, sourceFileData);
                    if (sourceIndex != -1)
                        files.RemoveAt(sourceIndex);
                }
            }
            e.Handled = true;
        }
        private void ListBoxItemDragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine(e.Effects);
            if (!e.Data.GetDataPresent(typeof(FileData)) && !e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }
