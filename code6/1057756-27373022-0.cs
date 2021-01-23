    foreach(object t in Enum.GetValues(typeof(Status)))
    {
       var memInfo = enumType.GetMember(t.ToString());
       var attrs = memInfo[0].GetCustomAttributes(false).OfType<EnumMember>();
       var attr = attrs.FirstOrDefault();
       if(attr != null)
       {
            string val = attr.Value;
            // do what you want with val....
       }
    }
