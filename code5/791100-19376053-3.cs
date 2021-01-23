    public Book(int id, string name, params Tag tags)
    {
        this.Id = id;
        this.Name = name;
        this.tags = tags
            .Select(tag => new Tag { Id = tag.id, Name = tag.Name, Book = this })
            .ToList();
    }
