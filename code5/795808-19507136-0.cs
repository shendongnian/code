    this.myGridView.ShowingEditor += (sender, args) => 
    { 
        var gridView = sender as GridView;
        if(null != gridView)
        {
            var currentRowHandle = gridView.FocusedRowHandle;
            var currentType = gridView.Rows[currentRowHandle].GetType();
            if(currentType == typeof(TypeA))
            {
                 //Make a ListBox
            }
            if(currentType == typeof(TypeB))
            {
                //Make a TextBox
            }
        }
    }
