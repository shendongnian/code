    static string[,] ClassNames =
    {
       {"A","Red"},
       {"B","Blue"},
       {"C","Pink"},
       {"D","Green"},
       // and so on
    };
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string className = e.Row.Cells[2].Text;
        string color = "Black";
        for (int i = 0; i <= ClassNames.GetUpperBound(0); i++)
        {
            if (ClassNames[i, 0] == className)
            {
                color = ClassNames[i, 1];
                e.Row.Cells[2].ForeColor = Color.FromName(color);
                e.Row.Cells[2].BorderColor = Color.Black;
                break;
            }
        }
    }
