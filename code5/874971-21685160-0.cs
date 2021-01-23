    private void BandedGridView1_RowCellStyle(object sender,DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
    {
        if(e.CellValue > 70)
        {
           e.Appearance.ForeColor = Color.Green;
        } 
           
    }
        
    
