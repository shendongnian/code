    public class Test
    {
       // ...
       public virtual ICollection<TestQuestion> Questions { get; set; }
    }
    
    public class TestQuestion
    {
       public virtual Test Test { get; set; }
       public virtual Question Question { get; set; }
       public int Order { get; set; }
    }
    
    public class Question
    {
       // ...
    }
