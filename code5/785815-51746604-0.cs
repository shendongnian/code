     public static void GetGridSelectedView(out string tuid, ref DataGrid dataGrid,string Column)
        {
            try
            {
                // grid selected row values
                var item = dataGrid.SelectedItem as DataRowView;
                if (null == item) tuid = null;
                if (item.DataView.Count > 0)
                {
                    tuid =  item.DataView[dataGrid.SelectedIndex][Column].ToString().Trim();
                }
                else { tuid = null; }
            }
            catch (Exception exc) { System.Windows.MessageBox.Show(exc.Message); tuid = null; }
        }
