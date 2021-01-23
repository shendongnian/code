    public static void UpdateUser(User user)
    {
        using (Context DB = new Context())
        {
            DB.UpdateGraph(user, map => map.AssociatedCollection(u => u.Friends));                
            DB.SaveChanges();
        }
    }
