        var pathExtension = Path.GetExtension(fileName);
        var connectionString = string.Empty;
        if (pathExtension == ".xls")
        {
          connString = string.Format(@"PProvider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=\"Excel 8.0;HDR=YES\";", yourPath)
        }
        if (pathExtension == ".xlsx")
        {
          connString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\", yourPath)
        }
