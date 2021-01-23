         private void dataGrid_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle > 0)
            {
                ColumnView View = dataGrid.MainView as ColumnView;
                DevExpress.XtraGrid.Columns.GridColumn col = View.Columns["ID"];
                if (Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, col)) % 2 == 0)
                {
                    e.Appearance.BackColor = Color.LightCyan;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }
