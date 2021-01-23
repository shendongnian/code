    delegate void SetDataSourceHandler(DataTable data); 
    
    public void SetDataSource(dDataTable data)
    {
        if (gvData.InvokeRequired)
                {
                    gvData.Invoke(new SetDataSourceHandler(SetDataSource), new object[] { data });
                    return;
                }
                nodosDataTableBindingSource.DataSource = data;
                
            }
    
    async Task ProcesarMensajes()
    {
    ...
     SetDataSource( GetList(nodes));
    }
