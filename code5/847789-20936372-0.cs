    try
    {
        using (var context = new DBEntities())
        {
            var query = (from c in context.Service
                            where serviceIds.Any(t=> t.ID == c.ServiceId)
                            select new
                            {
                                serviceId = c.ServiceId,
                                serviceName = c.ServiceName,
                                rate = c.Rate
    
                            }).ToList();
    
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
    
        }
    }
    catch (Exception ex)
    {
        throw ex;
    }
