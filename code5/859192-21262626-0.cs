       public class Comment
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string Text { get; set; }        
            public List<Comment> Children { get; set; }
        }
    
        class Program
        {
            static void Main()
            {
            List<Comment> categories = new List<Comment>()
                {
                    new Comment () { Id = 1, Text = "Item 1", ParentId = 0},
                    new Comment() { Id = 2, Text = "Item 2", ParentId = 0 },
                    new Comment() { Id = 3, Text = "Item 3", ParentId = 0 },
                    new Comment() { Id = 4, Text = "Item 1.1", ParentId = 1 },
                    new Comment() { Id = 5, Text = "Item 3.1", ParentId = 3 },
                    new Comment() { Id = 6, Text = "Item 1.1.1", ParentId = 4 },
                    new Comment() { Id = 7, Text = "Item 2.1", ParentId = 2 }
                };
    
                List<Comment> hierarchy = new List<Comment>();
                hierarchy = categories
                                .Where(c => c.ParentId == 0)
                                .Select(c => new Comment() { Id = c.Id, Text = c.Text, ParentId = c.ParentId, Children = GetChildren(categories, c.Id) })
                                .ToList();
    
                HieararchyWalk(hierarchy);
    
                Console.ReadLine();
            }
    
            public static List<Comment> GetChildren(List<Comment> comments, int parentId)
            {
                return comments
                        .Where(c => c.ParentId == parentId)
                        .Select(c => new Comment { Id = c.Id, Text = c.Text, ParentId = c.ParentId, Children = GetChildren(comments, c.Id) })
                        .ToList();
            }
    
            public static void HieararchyWalk(List<Comment> hierarchy)
            {
                if (hierarchy != null)
                {
                    foreach (var item in hierarchy)
                    {
                        Console.WriteLine(string.Format("{0} {1}", item.Id, item.Text));
                        HieararchyWalk(item.Children);
                    }
                }
            }
