        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<string> selection = new List<string>();
            
            foreach (ListViewItem item in listView.SelectedItems)
            {
                int imgIndex = item.ImageIndex;
                selection.Add(filenames[imgIndex]);
            }
            DataObject data = new DataObject(DataFormats.FileDrop, selection.ToArray());
            DoDragDrop(data, DragDropEffects.Copy);
        }
