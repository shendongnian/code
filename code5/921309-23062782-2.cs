    [Table("User")]
    class User{
     [Key]
     public int idUser;
     public virtual Computer Computer;
    }
    [Table("Computer")]
    class Computer{
     [Key]
     public int idComputer;
     [Key, ForeignKey("User")]
     public int idUser;
     public virtual User user;
    }
