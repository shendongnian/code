    namespace Models
    {
        using System;
        using System.ComponentModel.DataAnnotations;
        public class EntityBase
        {
            public virtual Guid Id { get; set; }
        }
        public class Users : EntityBase
        {
            [Required]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-Z0-9]*$")]
            public virtual string Username { get; set; }
            // rest of entity
        }
        [TestFixture]
        public class ValidationTest 
        {
            [Test]
            public void Username_MustBeAlphanumeric()
            {
                var user = new Users()
                {
                    Id = Guid.NewGuid(),
                    Username = "R_",
                    Password = "secret"
                };
                // Althernative throws exception: 
                // Validator.ValidateObject(user, new ValidationContext(user), true);
                    
                var errors = new List<ValidationResult>();
                var ok = Validator.TryValidateObject(user, new ValidationContext(user), errors, true);
                Console.WriteLine("OK: {0}", ok);
                foreach (var error in errors)
                {
                    Console.WriteLine("Error '{0}' for members {1}", error.ErrorMessage, string.Join(", ", error.MemberNames));
                }
            }
        }
    }
