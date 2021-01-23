    var getClients = (from c in GeneralUtillities
        orderby c.Client_Name)
        .AsEnumerable()
        .Select (c =>  new
            {
                Client_Name = c.Client_Name.Trim(),
                Client_Code = c.Client_Code,  // for readability, not necessary
            });
