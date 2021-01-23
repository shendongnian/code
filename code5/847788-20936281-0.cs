    var serviceIds = new int[] { 1, 2, 3, 4, 5, 6 };
    try
    {
        using (var context = new DBEntities())
        {
            var query = (from c in context.Service
                            where serviceIds.Contains(c.ServiceId)      //ServiceId is the primary key
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
