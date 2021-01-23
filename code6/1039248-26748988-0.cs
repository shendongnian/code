    // base class for composition
    public abstract class Composite
    {}
    // category, can either hold tasks or other categories
    public class Category : Composite
    {
        // list of child items, either tasks or categories
        ICollection<Composite> Children { get; set;}
    }
    // task is a leave node in the hierarchy
    public class Task : Composite
    {}
    // model will only hold categories
    public class Model
    {
        ICollection<Category> Categories { get; set;}
    }
