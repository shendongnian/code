    decimal a=0, b=0, c=0;
     
    for (int i = 0; i < (gridview1.Rows.Count); i++)
               {
                   a = Convert.ToDecimal(gridview1.Rows[i].Cells["Column Index"].Text.ToString());
                   c = c + a; //storing total qty into variable 
    }
