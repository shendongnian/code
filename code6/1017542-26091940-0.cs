    string[] HidingColumns = //Here populate string array with list of columns you want to hide.
                if(e != null)
                {
                    if(HidingColumns.Contains(e.Column.Header))
                    {
                        e.Cancel = true;
                    }
                }
