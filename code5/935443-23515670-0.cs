     public class  Modules_And_Questions
     {
       [Key, Column(Order = 1)]
       public int ModuleId {get;set;}
       public Module Module {get;set;}
       [Key, Column(Order = 2)]
       public int QuestionId {get;set;}
       public Question ForeignKeyQuestion{get;set;}
     }
      modelBuilder.Entity<Modules_And_Questions>().HasRequired(m => m.Question).WithForeignKey(n=>n.QuestionId)
      modelBuilder.Entity<Modules_And_Questions>().HasRequired(m => m.Module).WithForeignKey(n=>n.ModuleId)
