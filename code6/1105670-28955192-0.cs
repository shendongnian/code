           public class Customer
            {
                public int CustomerId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
            
                public virtual EmailAddress PrimaryAddress { get; set; }
                public virtual EmailAddress SecondaryAddress { get; set; }
                public virtual EmailAddress TeritaryAddress { get; set; }
            }
            
            public class EmailAddress
            {
                public int EmailAddressId { get; set; }
                public string Address { get; set; }
            }
            
            public class ShoppingDb : DbContext
            {
                public DbSet<Customer> Customers { get; set; }
                public DbSet<EmailAddress> Addresses { get; set; }
            
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
            
                    var customerEntity= modelBuilder.Entity<Customer>();
                    customerEntity.HasKey(c => c.CustomerId);
                    customerEntity.Property(c => c.FirstName).HasMaxLength(50);
                    customerEntity.Property(c => c.LastName).HasMaxLength(50);
                    customerEntity.HasRequired(c =>  
     c.PrimaryAddress).WithRequiredDependent();                 
                    customerEntity.HasOptional(c => c.SecondaryAddress).WithOptionalDependent();
                    customerEntity.HasOptional(c => c.TeritaryAddress).WithOptionalDependent();
            
                    var addressEntity = modelBuilder.Entity<EmailAddress>();
                    addressEntity.HasKey(c => c.EmailAddressId);
                    addressEntity.Property(c => c.Address).HasMaxLength(200);
                }
            }
