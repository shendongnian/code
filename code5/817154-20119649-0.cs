    private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
        GridView view = sender as GridView;
        
        if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
        {
            int rowHandle = e.HitInfo.RowHandle;
            e.Menu.Items.Clear();
            DXMenuItem zaznaczItem = new DXMenuItem("Zaznacz wszystkie", new EventHandler(zaznacz_Click));
            DXMenuItem odznaczItem = new DXMenuItem("Odznacz wszystkie", new EventHandler(odznacz_Click));
            e.Menu.Items.Add(zaznaczItem);
            e.Menu.Items.Add(odznaczItem);
        }
    }
    void zaznacz_Click(object sender, EventArgs e)
    {
         foreach (DataRow dr in (gcKontrahent.DataSource as DataTable).Rows)
         {
             dr["checkbox"] = true;
         }
    }
