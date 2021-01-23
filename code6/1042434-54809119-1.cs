   public override object Add(string key, object entry, DateTime utcExpiry)
        {
            var decodedKey = HttpUtility.UrlDecode(key)
              // implement your caching logic here 
            return entry;
        }
The Key parameter will always come in the Set Method with additional parameters - this is normal.
