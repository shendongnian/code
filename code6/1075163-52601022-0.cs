            foreach (var column in grid.Columns)
            {
                foreach(string columnName in columnNames)
                {
                    if (column.Header.ToString().ToLower() == columnName.ToLower())
                    {
                        column.Visibility = Visibility.Collapsed;
                        break;
                    }
                }
            }
        }
