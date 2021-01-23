      public String ToColumnName(Expression<Func<User,string>> column)
      {
         return ((MemberExpression)column.Body).Member.Name;
      }
      public bool FilterByColumns(User user, params Expression<Func<User,string>>[] columns) 
      {
         return FilterByColumnNames (user, columns.Select (ToColumnName).ToArray());
      }
