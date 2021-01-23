    public string getAge(Guid uID)
    {
        using (var context = new dbEntities())
        {
            var user = context.UserInformation.First(c => c.UserId == uID);
            if(user != null && !String.IsNullOrEmpty(user.Ålder))
              return user.Ålder;
            else
              return string.empty;
        }
    }
