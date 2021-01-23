    private void t_Resize(object sender, EventArgs e)
    {
       // assuming you want the two RTBs to fill the TabPage
       // if you want something else, best add an anchored container panel
       // and use its resize event instead
       T2.Width = t.Width / 4;
       T.Width = t.Width / 4;
    }
