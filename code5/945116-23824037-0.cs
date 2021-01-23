    class Program
    {
        static void Main(string[] args)
        {
            var sampleBook = new Book { 
                Id = 1, 
                Unities = new List<Unity> { 
                    new Unity { Id = 2, Title = "Title of unity" }, 
                    new Unity { Id = 3, Title = "Title of unity" } 
                } 
            };
            var ourBookDto = new DtoBook
            {
                Id = sampleBook.Id,
                Organization = new DtoOrganization
                {
                    Id = 666, // i don't know from where do you want to obtain this id
                    Unities = sampleBook.Unities.Select(u => new DtoUnity { 
                        Id = u.Id,
                        Title = u.Title
                    }).ToList()
                }
            };
            Console.ReadLine();
        }
    }
