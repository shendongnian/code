    private string GetPhone(User user)
    {
        if (user == null)
            return null;
        return user.Phone;
    }
// ...
    var newList = from user in allUsers.ToList()
                  select new
                  {
                      user.FirstName,
                      user.LastName,
                      user.Email,
                      Phone = GetPhone(user)
                  };
