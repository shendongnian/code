    return (from p in lstProvisions
            group x by x.Name into y
            where y.Count() > 1
            from z in y
            select new FieldConfiguration()
              {
                Name = p.Name,
                ProvisionFieldID = p.ID.ToString(),
                FieldType = Configuration.SyncapayPlus.FieldType.Provision,
                SourceOption = p.OptionValue.ToString(),
                Caption = (from b in benefits
                           where b.Key == p.BenefitID
                           select string.Format("{0}_{1}", b.Value, p.Name)
                          ).ToString()
              }
           ).ToList()
