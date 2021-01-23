          string value = null;
          if (HttpContext.Current.User != null) {
            value = HttpContext.Current.User.Identity.Name;
          } else {
            value = HttpContext.Current.Request.LogonUserIdentity.Name;
          }
          var split = value.Split(new char[] { '\\' });
          var userName = split[split.Length - 1];
          using (var cmd = new SqlCommand("SELECT * FROM FixPrice WHERE UserName=@UserName", new SqlConnection("mtbase")))
          {
             // Add your parameter before opening the connection
             cmd.Parameters.AddWithValue("@UserName", userName);
             // Open connection
             cmd.Connection.Open();
             using (var reader = cmd.ExecuteReader()) {
                ...
             }
             cmd.Connection.Close();
          }
