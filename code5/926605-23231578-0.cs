    SqlConnection cn = null;
    
    try {
        cn = HostFacade.GetDbConnection();
        cn.Open();
        // .. rest of the code here
    }
    finally {
        if (cn != null)
            cn.Dispose();
    }
