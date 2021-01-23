    User user = list.FirstOrDefault(x => x.UserName == "John");
    if (user != null)
    {
        // Use user
    }
    else{
       // create a new one
    }
