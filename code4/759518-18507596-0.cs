    Parent parentAlias = null;
    Child childAlias = null;
    return session.QueryOver<Parent>(() => parentAlias).WithSubquery
          .WhereExists(QueryOver.Of<Child>(() => childAlias)
             .Where(() => parentAlias.Id == childAlias.Parent.Id)
             .Select(c => childAlias.Id))
          .SingleOrDefault();
