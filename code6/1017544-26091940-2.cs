        if(e != null)
        {
            if(arr.Contains(e.Column.Header))
            {
                e.Cancel = true;
               //Here if you want to just hide the column and wants to generate the column
               // e.Column.Visibility= Visibility.Collapsed;
            }
        }
