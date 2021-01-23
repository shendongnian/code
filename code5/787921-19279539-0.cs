    GridView View = sender as GridView;
        string firstName = View.GetRowCellDisplayText(e.RowHandle, View.Columns["FirstName"]);
    
          if (firstName=="Sharp")
          {
            e.Appearance.BackColor = Color.Salmon;
            e.Appearance.BackColor2 = Color.White;
          } 
         else
     {   
         DataSet ds = view.DataSource as DataSet;
         if(ds != null)
         {
             //add the column to the table you want if it doesn't exist
         }
     }
