    DataTable table= new DataTable();
    SqlDataReader dr = cmd.ExecuteReader();
    SqlDataReader dr = cmd.ExecuteReader();
        
    table.Load(dr);
        
    for (int i = 0; i < table.Rows.Count; i++)
    {
        Xdate= table.Rows[i]["Datum"].ToString();
        Yminuten= table.Rows[i]["Minuten"].ToString();
                   
        Chart1.Series["Testing"].Points.AddXY(Xdate, Yminuten);               
        Chart1.Series["Testing"].Color = Color.Goldenrod;
    }    
        
    Chart1.DataBind();
