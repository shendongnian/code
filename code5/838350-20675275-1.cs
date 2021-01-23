    IEnumerable<lst> fnc(string category)
    {
        return JoinByCategory(sample.TableName, category)
                 .Where(t1 => t1.cat == category);
    }
    private IQueryable<T1> JoinByCategory(IQueryable<T1> outer, string category)
    {
       switch(category)
       {
          case "A": return outer.Join(sample.A, t1=> t1.id, a=> a.id, (t1,a)=> t1);
          case "B": return outer.Join(sample.B, t1=> t1.Eid, b=> b.id, (t1,b)=> t1);
          ...
          default:
             throw new ArgumentException();
       }
    }
