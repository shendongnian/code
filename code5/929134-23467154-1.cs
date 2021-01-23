     private void NewRow(object obj)
        {
            if (SelectedRow == People.Last())
            {
                if (SelectedConfirmation == "Add New")
                {
                    if (_lastCell.Column !=null && _lastCell.Column.Header.ToString() =="Age")//here is my edit
                    {
                        People.Add(new Person());
                    }
                }
            }
        }
