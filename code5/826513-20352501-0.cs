    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Objects.SqlClient;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    namespace testef {       
        [Table("Users")]
        public class User {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public System.DateTime DateOfBirth { get; set; }
            public string Email { get; set; }
            public string AboutYourself { get; set; }
            public string Guitar { get; set; }
            public string Country { get; set; }
            public string ProfilePic { get; set; }
            public virtual ICollection<Song> Songs { get; set; }
            public virtual ICollection<Song> UserLikes { get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
        }
        [Table("Songs")]
        public class Song {
            public int SongID { get; set; }
            public string Name { get; set; }
            public string Genre { get; set; }
            public string File { get; set; }
            public System.DateTime DateOfPost { get; set; }
            public string Lyrics { get; set; }
            public short Likes { get; set; }
            public int UserUserID { get; set; }
            public virtual User User { get; set; }
            public virtual ICollection<User> UsersWhoLiked { get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
        }
        [Table("Comments")]
        public class Comment {
            public int CommentID { get; set; }
            public int UserUserID { get; set; }
            public int SongSongID { get; set; }
            public virtual Song Song { get; set; }
            public virtual User User { get; set; }
        }
        public class TestEFContext : DbContext {
            public DbSet<User> Users { get; set; }
            public DbSet<Song> Songs { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public TestEFContext(String cs)
                : base(cs) {
                Database.SetInitializer<TestEFContext>(new DropCreateDatabaseAlways<TestEFContext>());
                
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Comment>().HasRequired(x => x.Song).WithMany(y => y.Comments).WillCascadeOnDelete(false);
                modelBuilder.Entity<Comment>().HasRequired(x => x.User).WithMany(y => y.Comments).WillCascadeOnDelete(false);
            }
        }
        class Program {
            static void Main(string[] args) {
                String cs = @"Data Source=ALIASTVALK;Initial Catalog=TestEF;Integrated Security=True; MultipleActiveResultSets=True";
                using (TestEFContext ctx = new TestEFContext(cs)) {                 
                    Console.WriteLine("The value is " + ctx.Users.Count().ToString());
                }
            }
        }
    }
