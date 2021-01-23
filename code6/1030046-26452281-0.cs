    string cell = dt.Rows[totalnumberA][0].ToString();
    
    string itemx = cell.PadLeft(6, '0');
    string item2 = "*" + itemx + "*";
    string item3 = "*UMS" + itemx + "*";
    
    e.Graphics.DrawString(itemx, new Font("Free 3 of 9", 30, FontStyle.Regular), Brushes.Black,          xValue, yValue);
    e.Graphics.DrawString(item3, new Font("Courier New", 14, FontStyle.Regular), Brushes.Black,  xValue, yValue2);
    
    if (totalnumberA < dt.Rows.Count)
    {
        e.HasMorePages = true;
        totalnumberA++;
    }
    else
    {
        e.HasMorePages = false;
    }
