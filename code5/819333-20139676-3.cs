    public class IntEntity<TEntity> : IEntity<TEntity, int>
       where TEntity : IntEntity<TEntity>
    {
        public int Id { get; set; }
        public Expression<Func<TEntity, int>> GetIdExpression()
        {
            return (Expression<Func<TEntity, int>>)(e => e.Id);
        }
        public int EntityId
        {
            get { return this.Id; }
        }
    }
    //let it be the auto-generated part:
    public partial class Entity2
    {
        public int Id { get; set; }
    }
    //and the manual part:
    public partial class Entity2 : IntEntity<Entity2>
    {
        public void SetId(int id)
        {
            Id = id;
            base.Id = id;
        }
    }
    var re = new Entity2();
    re.SetId(5);
    Console.WriteLine(re.Id); //5
    Console.WriteLine(re.GetIdExpression().Compile()(re)); //5
