    public void LoadObjects(ref List<Provider> providers, ref List<ProviderDetail> providerDetail)
    {
      DataTable dt = GetListofProviders();
      Provider p = New Provider();
      ProviderDetail pd = new ProviderDetail();
      if(dt.rows.count > 0)
      {
          For Each(DataRow dr in dt)
          {
              p.ProviderID = dr.Item["ProviderId"].ToInt32();
              p.FirstName = dr.Item["FirstName"].ToString();
              .....continue to load object and add it to list
              providers.Add(p);
              pd.ProviderDetailsID = dr.Item["ProviderDetailsID"].ToInt32();
              pd.Certification = dr.Item["Certification"].ToString();
              .....continue to load object and add it to list
              providerDetails.Add(pd);
          }
      }
      else
      {
           ...do something else
      }
    }
