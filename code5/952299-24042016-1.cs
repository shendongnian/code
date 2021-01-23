    private void collectablePictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (sender != null && e.LeftButton == MouseButtonState.Pressed)
        {
            this.SelectedSection.AllowDrop = true;
            this.SelectedSection.DragEnter += new DragEventHandler(this.CollectableSelectedSection_DragEnter);
            this.SelectedSection.DragDrop += new DragEventHandler(this.CollectableSelectedSection_DragDrop);
            this.collectablePictureBox.DoDragDrop(this.SelectedClassModel, DragDropEffects.Copy);
        }
    }
