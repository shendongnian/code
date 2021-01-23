     public partial class myEntities
        {
           public List<MyClass> usp_GetTestRecords(int _p1, int _p2, string _groupId)
           {
              // fill out params
              SqlParameter p1 = new SqlParameter("@p1", _p1);
              ...
              obj[] parameters = new object[] { p1, p2, groupId };
        
              // call the proc
              return this.Database.SqlQuery<MyClass>(@"EXECUTE usp_GetTestRecords @p1, @p2, @groupId", parameters).ToList();
           }
        }
