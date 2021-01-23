    private void paTG_DragDrop(object sender, DragEventArgs e)
    {
        var data = e.Data.GetData(typeof(Color));
            
        if(data != null)
            ((Panel)sender).BackColor = (Color)data;
    }
    private void paAC_MouseDown(object sender, MouseEventArgs e)
    {
        Panel pnl = sender as Panel;
        if(pnl != null)
            pnl.DoDragDrop(pnl.BackColor, DragDropEffects.Move);
    }
