    private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                FrameworkElement element1 = datagrid.Columns[0].GetCellContent(e.Row);
                if (element1.GetType() == typeof(TextBox))
                {
                    var colomn1 = ((TextBox)element1).Text;
                    objToAdd.Column1 = Convert.ToInt32(Column1);
                }
                FrameworkElement element2 = datagrid.Columns[1].GetCellContent(e.Row);
                if (element2.GetType() == typeof(TextBox))
                {
                    var colomn2 = ((TextBox)element2).Text;
                    objToAdd.Column2 = Convert.ToInt32(Column2);
                }
                FrameworkElement element3 = datagrid.Columns[2].GetCellContent(e.Row);
                if (element3.GetType() == typeof(TextBox))
                {
                    var colomn3 = ((TextBox)element3).Text;
                    objToAdd.Column3 = Convert.ToInt32(Column3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
