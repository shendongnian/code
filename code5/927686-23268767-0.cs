    private void advBandedGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) 
    {
       GridView currentView = sender as GridView;
       if(e.RowHandle == currentView.FocusedRowHandle) return;
       Rectangle r = e.Bounds;
       
       if(e.Column.FieldName == "UnitsInStock") 
       {
          bool check = (bool)currentView.GetRowCellValue(e.RowHandle, 
          currentView.Columns["Discontinued"]);
          if(check) 
          {
            //Change the text to display
            //The e.Handled parameter is false
            //So the cell will be painted using the default appearance settings
            e.DisplayText = "Discontinued";                    
           }
           else 
           {
            // If the cell value is greater then 50 the paint color is LightGreen, 
            // otherwise LightSkyBlue 
            Brush ellipseBrush = Brushes.LightSkyBlue;
            if (Convert.ToInt16(e.CellValue) > 50) ellipseBrush = Brushes.LightGreen;
            //Draw an ellipse within the cell
            e.Graphics.FillEllipse(ellipseBrush, r);
            r.Width -= 12;
            //Draw the cell value
            e.Appearance.DrawString(e.Cache, e.DisplayText, r);
            //Set e.Handled to true to prevent default painting
            e.Handled = true;
           }
       }
    }
