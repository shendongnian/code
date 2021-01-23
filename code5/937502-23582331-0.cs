    public User(Dictionary<String, String> data)
    {
       var fields = typeof(User).GetFields();
       foreach (field in fields)
       {
          if (data.ContainsKey(field.Name))
          {
             var value = Convert.ChangeType(data[field.Name], field.MemberType);
             field.SetValue(this, value);
          }
       }
    }
