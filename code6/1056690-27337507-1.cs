        var group = dbContext.Groups.FirstOrDefault(x => x.GroupName == groupName);
        try
        {
            if (group == null)
            {
                group  = new Group();
                group.GroupName = groupName;
                dbContext.Groups.Add(group);                     
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
