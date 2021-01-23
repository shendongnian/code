    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    namespace TestConsole
    {
        public class PersonnelInfo
        {
            [Required]
            [Key]
            public int PersonId { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
    
            public int GenderId { get; set; }
            [Required]
            public Gender Gender { get; set; }
        }
    
        public class Gender
        {
            [Key]
            public int GenderId { get; set; }
            public string GenderName { get; set; }
        }
    
    
    
        internal class Program
        {
            public TestConsoleDbContext MyDbContext { get; set; }
    
            public Program()
            {
                MyDbContext = new TestConsoleDbContext();
            }
    
            private static void Main(string[] args)
            {
    
                var program = new Program();
                program.CreateData();
    
                var records = from p in program.MyDbContext.PersonnelInfos
                              select new { p.FirstName, p.LastName, p.Gender.GenderName };
    
                foreach (var r in records)
                {
                    Console.WriteLine("Name: {0} {1} Gender: {2}", r.FirstName, r.LastName, r.GenderName);
                }
    
                Console.ReadLine();
    
    
            }
    
            private void CreateData()
            {
                var record = new PersonnelInfo() { FirstName = "First Name 1", LastName = "Last Name 1", GenderId = GetGenderIdbyName("male") };
                var record1 = new PersonnelInfo() { FirstName = "First Name 2", LastName = "Last Name 2", GenderId = GetGenderIdbyName("female") };
                
                MyDbContext.PersonnelInfos.Add(record);
                MyDbContext.PersonnelInfos.Add(record1);
                MyDbContext.SaveChanges();
            }
    
            private int GetGenderIdbyName(string genderName)
            {
                var genderRecord = (from g in MyDbContext.Genders
                                    where g.GenderName.Equals(genderName, StringComparison.CurrentCultureIgnoreCase)
                                    select g).FirstOrDefault();
    
                var genderId = 0;
    
    
                if (genderRecord == null)
                {
                    var gender = new Gender() { GenderName = genderName };
    
                    MyDbContext.Genders.Add(gender);
                    MyDbContext.SaveChanges();
                    genderId = gender.GenderId;
    
                }
                else
                {
                    genderId = genderRecord.GenderId;
                }
    
                return genderId;
    
            }
        }
    }
    using System.Data.Entity;
    
    namespace TestConsole
    {
        internal class TestConsoleDbContext : DbContext
        {
            public IDbSet<PersonnelInfo> PersonnelInfos { get; set; }
            public IDbSet<Gender> Genders { get; set; }
        }
    }
