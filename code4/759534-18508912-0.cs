    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Database.Delete();
    
                Question q1 = new Question
                {
                    Title = "Title1",
                    Tags = new List<Tag> 
                        { 
                            new Tag {Name = "Tag1", CreateDate = DateTime.UtcNow, LastEditDate = DateTime.UtcNow },
                            new Tag {Name = "Tag2", CreateDate = DateTime.UtcNow, LastEditDate = DateTime.UtcNow }, 
                            new Tag {Name = "Tag3", CreateDate = DateTime.UtcNow, LastEditDate = DateTime.UtcNow }, 
                        }
                };
    
                ctx.Questions.Add(q1);
                ctx.SaveChanges();
            }
    
            Question q2 = new Question
                {
                    Title = "Title1",
                    Tags = new List<Tag> 
                        { 
                            new Tag {Id = 1, Name = "Tag1"},
                        }
                };
    
            using (MyContext ctx = new MyContext())
            {
                foreach (Tag t in q2.Tags)
                {
                    DbEntityEntry<Tag> entry = ctx.Entry(t);
                    if (entry.State == System.Data.EntityState.Detached)
                    {
                        ctx.Tags.Attach(t);
                    }
                }
    
                ctx.Questions.Add(q2);
                ctx.SaveChanges();
            }
        }
    }
    
    public class Question
    {
        public int Id { get; set; }
    
        public string Title { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
    
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
    
    public class MyContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
