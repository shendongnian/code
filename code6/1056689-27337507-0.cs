        var group = dbContext.Groups.FirstOrDefault(x => x.GroupName == groupName);
        try
        {
            if (group == null)
            {
                var newGroup = new Group();
                newGroup.GroupName = groupName;
                dbContext.Groups.Add(newGroup);                     
            }
            group.Users.Add(user);
            dbContext.SaveChanges();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error occured! " + ex.message);
            dbTransaction.Rollback();
        }
        dbTransaction.Commit();
