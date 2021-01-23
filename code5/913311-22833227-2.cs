    private void lst_SubControls_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(MyControl2)))
            e.Effect = DragDropEffects.Move;
        else e.Effect = DragDropEffects.None;
    }
    private void lst_SubControls_DragDrop(object sender, DragEventArgs e)
    {
        lst_SubControls.Items.Add(((MyControl2)e.Data.GetData(typeof(MyControl2))).SpecificDrive);
        ((MyControl2)e.Data.GetData(typeof(MyControl2))).DeleteThisControl();
    }
