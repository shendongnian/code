    public void TestCase(object sender, EventArgs e)
        {
            var entity = new AIRLINE(){ 
                Name = "111"
            };
            if(IsExists<AIRLINE>(entity, en => en.Name == entity.Name))
                throw new Exception("Already exists");
        }
    
        public class AIRLINE {
            public string Name { get; set; }
        }
    
        DbContext context = new DbContext(null);
    
        public bool IsExists<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> condition) where TEntity : class {
            DbSet<TEntity> dataSet = context.Set<TEntity>();
            if(!dataSet.Any(condition)) {
                dataSet.Add(entity);
                return false;
            } else
                return true;
        }
