    public int Sum()
    {
        int z = 0;
        int i;
        int x = 0;
        for (i = 0; i < GridView1.Columns.Count; i++)
        {
            x += int.Parse(GridView1.Rows[0].Cells[i].Text);
            
        }
    return x;
    }  
