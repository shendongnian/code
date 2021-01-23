    GRD.Items.Count;
    DataGridRow row = (DataGridRow) GRD.ItemContainerGenerator.ContainerFromIndex(i);     
    DataGridCell TXTGROUPID = GRD.Columns[2].GetCellContent(row).Parent as DataGridCell;               
    string str = ((TextBlock) TXTGROUPID.Content).Text;
    MessageBox.Show(str);
            
