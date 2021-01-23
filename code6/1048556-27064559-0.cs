    string cellText = "";
    
      for (int i = 0; i < GridView1.Rows.Count; i++)
        {
           for (int k = 0; k < GridView1.Rows[i].Cells.Count; k++)
             {
                cellText += GridView1.Rows[i].Cells[k].Text;
             }
        }
