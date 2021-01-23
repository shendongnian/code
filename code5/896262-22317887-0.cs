    this.NavigationService.Navigate(new Uri(string.Format("LocationView.xaml?GeoX={0}&GeoY={1}", GeoX, GeoY), UriKind.Relative));
      if (NavigationContext.QueryString.ContainsKey("GeoX") && NavigationContext.QueryString.ContainsKey("GeoY"))
      {
      double GeoX =Convert.ToDouble(NavigationContext.QueryString["GeoX"].ToString());
      double GeoY = Convert.ToDouble(NavigationContext.QueryString["GeoY"].ToString());
