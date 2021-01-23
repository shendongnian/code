    using (Vendor c = new Vendor())
    {
      var query = (from p in c.Orders
                   where (p.VendorID == vendorId ||
                          p.ParentVendorID == parentVendorId)
                   select p).ToList();
    
      if (query.Count() > 0)
      {
          for (int i = 0; i <= query.Count() - 1; i++)
          {
              query[i].OrderTag = tag;
              query[i].OrderDescription = desc;
              query[i].ProductSegment = productSegment;
              query[i].ProductSegmentCategory = productCategory;
          }
    
          c.SaveChanges();
      }
    }
