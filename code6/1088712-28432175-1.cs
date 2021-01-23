    public virtual User GetUserWithResources(string username)
    {
        using (ISession session = GetSession())
        {
          Resource resAlias = null;           
    
          return session.QueryOver<User>()
              .Where(user => user.Login == username)
              .JoinQueryOver(x => x.Resources)
                  .JoinQueryOver(res => res.Versions)
              .TransformUsing(Transformers.DistinctRootEntity)
              .List<User>().SingleOrDefault();
        }
    }
