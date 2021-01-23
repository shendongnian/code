    // This declaration will allow us, to use a reference from middle SELECT
    // in the most deeper SELECT
    Response response = null;
    
    // the most INNER SELECT
    var maxSubquery = QueryOver.Of<Response>()
       .SelectList(l => l
        .SelectGroup(item => item.RequestId)
        .SelectMax(item => item.DateTime)
        )
        // WHERE Clause
       .Where(item => item.RequestId == response.RequestId)
       // HAVING Clause
       .Where(Restrictions.EqProperty(
          Projections.Max<Response>(item => item.DateTime),
          Projections.Property(() => response.DateTime)
        ));
    
    // the middle SELECT
    var successSubquery = QueryOver.Of<Response>(() => response)
        // to filter the Request
        .Select(res => res.RequestId)
        .WithSubquery
        .WhereExists(maxSubquery)
        // now only these wich are successful
        .Where(success => success.Success == true)
        ;
