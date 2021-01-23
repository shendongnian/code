    private void LongListSelector_SelectionChanged(object sender, BlahBlah e)
    {
         var tb = sender as Textblock;
         string cName = tb.Text; //This is the string you wanted.
         MessageBox.Show(cName);
    }
