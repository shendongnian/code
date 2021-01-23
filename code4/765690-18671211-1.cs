    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string ClassName = e.Row.Cells[2].Text;
        Color FontColor = Color.Black;
        switch (ClassName)
        {
            case "A":
                FontColor = Color.Red;
                break;
            case "B":
                FontColor = Color.Blue;
                break;
            case "C":
                FontColor = Color.Yellow;
                break;
            case "D":
                FontColor = Color.Green;
                break;
        }
        e.Row.Cells[2].ForeColor = FontColor;
        e.Row.Cells[2].BorderColor = Color.Black;
    }
