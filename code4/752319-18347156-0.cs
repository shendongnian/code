    //Set up the source cookie container
    var cookieContainerA = new CookieContainer();
    cookieContainerA.Add(new Uri("http://foobar.com"), new Cookie("foo", "bar"));
    cookieContainerA.Add(new Uri("http://foobar.com"), new Cookie("baz", "qux"));
    cookieContainerA.Add(new Uri("http://abc123.com"), new Cookie("abc", "123"));
    cookieContainerA.Add(new Uri("http://abc123.com"), new Cookie("def", "456"));
    //Set up our destination cookie container
    var cookieContainerB = new CookieContainer();
    //Get the domain table member
    var type = typeof(CookieContainer);
    var domainTableField = type.GetField("m_domainTable", BindingFlags.NonPublic | BindingFlags.Instance);
    var domainTable = (Hashtable)domainTableField.GetValue(cookieContainerA);
    foreach (var obj in domainTable)
    {
      var entry = (DictionaryEntry)obj;
      
      //The domain is the key (we only need this for our Console.WriteLine later)
      var domain = entry.Key;
      var valuesProperty = entry.Value.GetType().GetProperty("Values");
      var values = (IList)valuesProperty.GetValue(entry.Value);
      foreach (var valueObj in values)
      {
        //valueObj is a CookieCollection, cast and add to our destination container
        var cookieCollection = (CookieCollection)valueObj;
        cookieContainerB.Add(cookieCollection);
        //This is a dump of our source cookie container
        foreach (var cookieObj in cookieCollection)
        {
          var cookie = (Cookie)cookieObj;
          Console.WriteLine("Domain={0}, Name={1}, Value={2}", domain, cookie.Name, cookie.Value);
        }
      }
    }
    //Test the copying
    //var foobarCookies = cookieContainerB.GetCookies(new Uri("http://foobar.com"));
    //var abc123Cookies = cookieContainerB.GetCookies(new Uri("http://abc123.com"));
