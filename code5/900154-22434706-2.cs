    private static readonly Func<Book, BookDto> AsBookDtoFunc =
            x => new BookDto
            {
                Title = x.Title,
                Author = x.Author.Name,
                Genre = x.Genre,
                Description = x.Description,
                Price = x.Price,
                PublishDate = x.PublishDate
            };
    
    private static readonly Expression<Func<Book, BookDto>> AsBookDto = 
            x => AsBookDtoFunc(x);
