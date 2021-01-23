    private void preventDragEmpty(object sender, DragEventArgs e)
    {
        List<dynamic> h = new List<dynamic>();
        try
        {
            //i'm using GongSolutions to handle drag and drop wich is highlly recommended
            //but if you dont use it just adapt to the correct type!
            h = e.Data.GetData("GongSolutions.Wpf.DragDrop") as List<dynamic>;
            if (h != null)
            {
                h.Remove(h.FirstOrDefault(x => x.ToString() == "{NewItemPlaceholder}"));
                e.Data.SetData(h);
            }
        }
        finally
        {
            e.Handled = true;
        }
    }
