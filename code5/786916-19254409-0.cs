    public class Person
    {
        public int Id { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
    
    public class Category
    {
        public int Id { get; set; }
        public int Person_Id { get; set; }
        public string Name { get; set; }
    }
    
    var people = context.People.ToList();
    var categories = context.Categories.ToList();
    
    foreach (var p in people)
    {
        p.Categories = categories.Where(a => a.Person_Id == a.Id);
    }
