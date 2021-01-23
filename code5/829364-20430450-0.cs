    public class Parent
    {
        public int Id { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
    public class Report
    {
        public int Id { get; set; }
    }
    public abstract class Activity
    {
        public int Id { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Report Report { get; set; }
        // common activity properties
    }
    public class Food : Activity
    {
        // Food specific properties
    }
    public class Excercise : Activity
    {
        // Exercise specific properties
    }
