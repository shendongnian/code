    [Table("User")]
        class User{
         [Key]
         public int idUser;
         public ICollection<Computer> Computers;
        }
    
    [Table("Computer")]
        class Computer{
         [Key]
         public int idComputer;
         [ForeignKey("idUser")]
         public virtual User user;
        }
