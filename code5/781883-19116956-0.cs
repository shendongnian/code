    protected void grd_usuarios_RowEditing(object sender, GridViewEditEventArgs e)
    {
           grd_usuarios.EditIndex = e.NewEditIndex;
           bindGridview();
    }
    
    public void  bindGridview()
    {
       grd_usuarios.DataSource = yourDataTable;
       grd_usuarios.DataBind();
    }
