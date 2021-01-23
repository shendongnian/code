    if (cellprices >= onepoint5 && cellprices < threepoint0)
    {
           row.Cells[2].Style.BackColor = Color.Yellow;
    }
    else if (cellprices >= threepoint0)
    {
           row.Cells[2].Style.BackColor = Color.Orange;
    }
    else
    {
           //do nothing
    }
