      if (NavigationContext.QueryString.ContainsKey("GeoX") && NavigationContext.QueryString.ContainsKey("GeoY"))
      {
      double GeoX =Convert.ToDouble(NavigationContext.QueryString["GeoX"].ToString());
      double GeoY = Convert.ToDouble(NavigationContext.QueryString["GeoY"].ToString());
      ....
      }
