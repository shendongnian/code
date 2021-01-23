    static class IdGenerator
    {
        static int _id = 1;
        public static int Generate() { return _id++; }
    }
    class Tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Tree Parent { get; set; }
        public virtual ICollection<string> Files { get; set; }
        public virtual ICollection<Tree> Trees { get; set; }
        internal Tree ()
        {
            Id = IdGenerator.Generate();
            Name = String.Empty;
            ParentId = 0;
            Parent = null;
            Files = new List<string>();
            Trees = new List<Tree>();
        }
        public override string ToString()
        {
            return String.Join("\n", new[] { Id + "\t" + Path.Combine(Parent != null ? Parent.Name : String.Empty, Name) }.Union(Files).Union(Trees.Select(t => t.ToString()))) + "\n";
        }
        public static Tree CreateTree(string path, Tree parent, string pattern)
        {
            try
            {
                var tree = new Tree
                {
                    Parent = parent,
                    ParentId = parent != null ? parent.Id : 0,
                    Name = Path.GetFileName(path),
                    Files = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly).Select(f => Path.GetFileName(f)).ToArray(),
                };
                tree.Trees = Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly).Select(d => CreateTree(d, tree, pattern)).ToArray();
                return tree;
            }
            catch (UnauthorizedAccessException)
            { return new Tree(); }
        }
    }
