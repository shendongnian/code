    using System;
    using System.Data.Entity;
    using System.Linq;
    
    public class TestContext : DbContext
    {
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Thing> Things { get; set; }
    }
    
    public abstract class Base
    {
        public int Id { get; set; }
    }
    
    public class Box : Base
    {
        public string Title { get; set; }
    }
    
    public class Thing : Base
    {
        public string Name { get; set; }
    }
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new TestContext();
    
            DoIt(GetPropValue(db, "Boxes") as IQueryable<Base>);
            DoIt(GetPropValue(db, "Things") as IQueryable<Base>);
        }
    
        private static void DoIt(IQueryable<Base> b)
        {
            Console.WriteLine(
                b.Single(t => t.Id == 1).Id);
        }
    
        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
