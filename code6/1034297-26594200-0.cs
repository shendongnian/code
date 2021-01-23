    var contacts = new List<Contact>()
    {
        new Contact(){ 
            FirstName = "Najam", 
            Tags = new Collection<Tag>()
            {
                new Tag(){ Name = "author" },
                new Tag(){ Name = "blogger" },  
                new Tag(){ Name = "subscriber" }
            }
        },
        new Contact(){ 
            FirstName = "Mick", 
            Tags = new Collection<Tag>()
            {
                new Tag(){ Name = "author" },
            }
        },
            new Contact(){ 
            FirstName = "Ryan", 
            Tags = new Collection<Tag>()
            {
                new Tag(){ Name = "subscriber" }
            }
        },
    };
