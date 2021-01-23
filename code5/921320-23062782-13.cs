    [Table("User")]
        class User{
         [Key]
         public int idUser {get;set;}
         public ICollection<Computer> Computers {get;set;}
        }
    
    [Table("Computer")]
        class Computer{
         [Key]
         public int idComputer {get;set;}
         [ForeignKey("idUser")]
         public virtual User user {get;set;}
        }
