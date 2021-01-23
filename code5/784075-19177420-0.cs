    var s  = (from c in Context.Hospitals
              from h in Context.NHSTrusts
              where c.NHSTrust_NHSTrustID==h.NHSTrustID 
              && string.Format("{0},{1}",c.HospitalName,h.NHSTrustName).Equals("My hospital name including trust")
    
              select c.HospitalId).FirstOrDefault();
