    [Table(nameof(Folder))]
    public class Folder
    {
        public Folder()
        {
            // for SQLite
        }
        internal Folder(Json.Folder folder)
        {
            Id = folder.id;
            Title = folder.title;
            Lists = string.Join(",", folder.list_ids);
        }
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lists { get; set; }
        public int[] ListsArray => Lists.Split(',').Select(x => int.Parse(x)).ToArray();
    }
