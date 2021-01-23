    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    namespace ManyToManyUnderTheHoodSpike
    {
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CourseContext>());
            using (CourseContext context=new CourseContext())
            {
                context.Courses.Add(new Course("Top of the bill")
                {
                    PrerequisiteCourses = new List<Course>() 
                        {
                            new Course("My two cents"),
                            new Course("Counting to two")
                        }
                });
                context.SaveChanges();
            }
        }
    }
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Course
    {
        public Course() { }
        public  Course(string name)
        {
            Name = name;
        }
        public string Name {get;set;}
        public int CourseId{get;set;}
        public ICollection<Course> PrerequisiteCourses{get;set;}
        public ICollection<Course> FollowUpCourses{get;set;}
    }
    }
