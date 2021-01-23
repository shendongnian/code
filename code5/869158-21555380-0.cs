    dynamic adUser = psObject.BaseObject;
    Console.WriteLine("GivenName: {0}, Surname: {1}",adUser.GivenName.ToString(),adUser.Surname.ToString());
    dynamic memberof = psObject.Properties["MemberOf"].Value;    
    var firstGroup = memberof.ValueList[0].ToString();
    var allGroups = memberof.ValueList;
    foreach (var item in allGroups)
    {
       Console.WriteLine(item.ToString());
    }
