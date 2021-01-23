    Type = SomethingType.Type2;
    var memberInfo = Type.GetType().GetMember(Type.ToString());
    if (memberInfo.Any())
    {
        var attributes = memberInfo.First().GetCustomAttributes(typeof(DisplayAttribute), false);
        if (attributes.Any())
        {
            var name = ((DisplayAttribute)attributes.First()).Name;  // Type 2
        }
    }
