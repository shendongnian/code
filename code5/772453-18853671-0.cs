    private void chLB_BenötigteProzesse_MouseMove(object sender, MouseEventArgs e)
    {
    if (e.LeftButton != MouseButtonState.Pressed || this.chLB_BenötigteProzesse.SelectedItem == null)
            return;
        indexBefore = this.chLB_BenötigteProzesse.SelectedIndex;
        this.chLB_BenötigteProzesse.DoDragDrop(this.chLB_BenötigteProzesse.SelectedItem, DragDropEffects.Move);    
    }
