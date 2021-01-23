    public Cell GetCell(Point position)
        {
            Cell cell = new Cell();
            cell.Column = -1; 
            double total = 0;
            foreach (var column in boardGrid.ColumnDefinitions)
            {
                if(position.X < total)
                {
                    break;
                }
                cell.Column++;
                total += column.ActualWidth;
            }
            cell.Row = -1;
            total = 0;
            foreach (var row in boardGrid.RowDefinitions)
            {
                if(position.Y < total)
                {
                    break;
                }
                cell.Row++;
                total += row.ActualHeight;
            }
            return cell;
        }
