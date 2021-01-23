    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace EntityFrameworkUpdateSketch
    {
    public class A
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Akey {get;set;}
        public string Aname { get; set; }
        public virtual List<B> Blist {get;set;}
        public A()
        {
            Blist = new List<B>();
        }
    }
    public class B
    {
        public virtual A owner { get; set; }
        
        [ForeignKey("owner")]
        [Key, Column(Order = 0)]
        public int Akey { get; set; }
        [Key, Column(Order = 1)]
        public int Order { get; set; }
        public string Bname { get; set; }
    }
    public class Database: DbContext
    {
        public DbSet<A> As { get; set; }
        public DbSet<B> Bs { get; set; }
    }
    public class Program
    {        
        static void Main(string[] args)
        {
            // Make a new object            
            using (Database db = new Database())
            {
                A intodb = new A();
                intodb.Akey = 1;                
                intodb.Aname = "Name of A object";
                intodb.Blist.Add(new B() { Bname = "Name of B object one",Order=1 });
                intodb.Blist.Add(new B() { Bname = "Name of B object two",Order=2 });
                db.As.Add(intodb);
                db.SaveChanges();
            }
        
            // Update the object in database
           
            using (Database db = new Database())
            {                       
                // Imagine I got "update" from somewhere else
                A update = new A();
                update.Akey = 1;
                update.Aname = "New Name of A object";
                update.Blist.Add(new B() { Bname = "New Name of B object one" ,Akey=1, Order=1});
                update.Blist.Add(new B() { Bname = "New Name of B object two", Akey = 1, Order = 2 });
                update.Blist.Add(new B() { Bname = "A whole new object 3", Akey = 1, Order = 3 });
                db.Entry<A>(update).State = EntityState.Modified;                
                // Clear all existing B objects attached to the updated object
                var query = from c in db.Bs.AsEnumerable() where  c.Akey==update.Akey select c;
                foreach (var z in query)
                {
                    db.Bs.Remove(z);
                }
                // Readd B objects
                foreach (var i in update.Blist)
                {
                    db.Bs.Add(i);
                }
                db.SaveChanges();                              
            }
        }
       
    }
    }
