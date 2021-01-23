            LegendItem firstItem = new LegendItem();
            Font f = new Font("Serif", 14, FontStyle.Bold);
            LegendCell firstCell = new LegendCell();
                          
            for (int l = 0; l < list.Count;l++ )
            {
                firstCell.Text = list[l] + Environment.NewLine  +firstCell.Text;
              
                firstCell.Font = f;
            } firstItem.Cells.Add(firstCell);
