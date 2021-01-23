    foreach (ProductDto insertItem in insertList)
    {
    	var query = Session.CreateSQLQuery(@"insert into Cart (ProdCode, Qty,  CustId)
    					        			values (:prodCode, :qty, :custid)")                
    						.SetParameter("prodCode", insertItem.ProdCode, NHibernateUtil.String)
    						.SetParameter("qty", insertItem.Qty, NHibernateUtil.Int32)
    						.SetParameter("custid", insertItem.CustId, NHibernateUtil.String);
    	int result = query.ExecuteUpdate();
    }     
