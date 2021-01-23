    while (NodeIter.MoveNext())
    {
        txtResults2.Text += NodeIter.Current.GetAttribute("Title", "");
    }
 
