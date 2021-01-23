    merchant = string.Format("{0} {1}", person.FirstName, person.LastName); 
    var result = merchant.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    // this ^ won't work if firstName or lastName contain spaces, so you can use another separator:
    merchant = string.Format("{0}#{1}", person.FirstName, person.LastName); 
    var result = merchant.Split("#", StringSplitOptions.RemoveEmptyEntries);
    var firstName = result[0];
    var lastName = result[1];
