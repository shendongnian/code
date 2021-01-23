    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    namespace EFIndexTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new AppDbContext())
                {
                    var newUser = new User { UniqueKeyIntPart1 = 1, UniqueKeyIntPart2 = 1, UniqueKeyStringPart1 = "A", UniqueKeyStringPart2 = "A" };
                    context.UserSet.Add(newUser);
                    context.SaveChanges();
                }
            }
        }
        [MetadataType(typeof(UserMetadata))]
        public class User
        {
            public int Id { get; set; }
            public int UniqueKeyIntPart1 { get; set; }
            public int UniqueKeyIntPart2 { get; set; }
            public string UniqueKeyStringPart1 { get; set; }
            public string UniqueKeyStringPart2 { get; set; }
        }
        public class UserMetadata
        {
            [Index("IX_UniqueKeyInt", IsUnique = true, Order = 1)]
            public int UniqueKeyIntPart1 { get; set; }
            [Index("IX_UniqueKeyInt", IsUnique = true, Order = 2)]
            public int UniqueKeyIntPart2 { get; set; }
            [Index("IX_UniqueKeyString", IsUnique = true, Order = 1)]
            [MaxLength(50)]
            public string UniqueKeyStringPart1 { get; set; }
            [Index("IX_UniqueKeyString", IsUnique = true, Order = 2)]
            [MaxLength(50)]
            public string UniqueKeyStringPart2 { get; set; }
        }
        public class AppDbContext : DbContext
        {
            public virtual DbSet<User> UserSet { get; set; }
        }
    }
