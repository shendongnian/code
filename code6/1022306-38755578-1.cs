        private void HookOnEventHandlers_etc()
	    {
	        RXBox.DragEnter += RXBox_DragEnter;
            RXBox.DragDrop += RXBox_DragDrop;
	        RXBox.AllowDrop = true;
	        RXBox.EnableAutoDragDrop = true;
	    }
        private void RXBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void RXBox_DragDrop(object sender, DragEventArgs e)
        {
            RXBox.SelectedText = e.Data.GetData(DataFormats.Text).ToString();
            e.Effect = DragDropEffects.None; // with this the paste won't be doubled
        }
