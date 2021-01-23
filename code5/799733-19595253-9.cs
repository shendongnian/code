    List<DisplayEntity> entitylist = null;
    
    private void WindowForm_Load(object sender, EventArgs e)
    {
        // query is executed only here
        entitylist = dbcontext.Entities.OrderBy(e => e.OrderInt).ToList();
        RefreshList();
    }
    
    private void RefreshList()
    {    
        listBoxEntities.DataSource = entitylist.OrderBy(e => e.OrderInt).ToList();
    }
    
    private void ChangeOrder(int argIDPK, int argNewPosition)
    {
        DisplayEntity tempe = entitylist.First(e => e.IDPK == argIDPK);
        tempe.OrderInt = argNewPosition;
        RefreshList();
    }
