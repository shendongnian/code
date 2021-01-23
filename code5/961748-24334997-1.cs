    public class Title : IAggregateRoot, ITitle
    {
        public string Prefix { get; set; }
        public string Value { get; set; }
        public int Level { get; private set; }
        public void Create(int levelsAvailable, ITitleRepository repository)
        {
            for (int i = 1; i <= levelsAvailable; i++)
            {
                Title title = new Title(Prefix, Value) { Level = i };
                repository.Save(title);
            }
        }
    }
    public class Person : IEntityObject, IPerson 
    {
       public ITitle Title { get;set; }
       public string Name { get; set; }
    }
