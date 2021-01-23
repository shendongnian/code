     var newNotInOld = newTiles
      .Where(nt => !oldTiles
        .Any(ot => {
           string url = nt.Naviation.ToString();
           int index = url.IndexOf('?');
           bool containsScheme = false;
           if (index >= 0)
           {
               string queryString = url.Substring(++index);
               containsScheme = queryString.Split('&')
                 .Any(p => p.Split('=')[0].Equals("Scheme", StringComparison.InvariantCulture) 
                        && p.Split('=').Last().Equals(ot.Scheme, StringComparison.InvariantCultureIgnoreCase));
           }
           return containsScheme;
       }));
