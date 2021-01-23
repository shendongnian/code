        foreach (DataTable table in result.Tables)
        {
            GfoTopBox box1 = StuffData(table);
            Grid.SetRow(box1, j);
            Grid.SetColumn(box1, i);
            output.Children.Add(box1);
            i++;
            if (i >= output.ColumnDefinitions.Count)
            {
                i = 0;
                j++;
            }
        }
