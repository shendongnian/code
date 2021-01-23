    private static SiteQuery ParseSiteQuery(XElement sitequery)
    {
      return new SiteQuery
      {
          Id = Convert.ToInt32(sitequery.Element("Id").Value),
          UPCPackSize = Convert.ToInt32(sitequery.Element("UPCPackSize").Value),
          UPC_Code = sitequery.Element("UPC_Code").Value,
          crvId = sitequery.Element("crvId").Value,
          dept = Convert.ToInt32(sitequery.Element("dept").Value),
          description = sitequery.Element("description").Value,
          openQty = Convert.ToDouble(sitequery.Element("openQty").Value),
          packSize = Convert.ToInt32(sitequery.Element("packSize").Value),
          subDept = Convert.ToInt32(sitequery.Element("subDept").Value),
          unitCost = Convert.ToDecimal(sitequery.Element("unitCost").Value),
          unitList = Convert.ToDecimal(sitequery.Element("unitList").Value),
          vendorId = sitequery.Element("vendorId").Value,
          vendorItem = sitequery.Element("vendorItem").Value,
      };
    }
