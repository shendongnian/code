    private void btnUpdate_Click(object sender, EventArgs e)
    {
        TModel t = new TModel();
        t.ID = 1;
        t.Name = "a";
        TestDBEntities en = new TestDBEntities();
    
        var entity = en.T.First(m => m.ID == 1);
        
        Mapper.Map<TModel, T>(t, entity);
        en.SaveChanges();
        MessageBox.Show("Update");
    }
