        List<Genre> unified = list1.Join(list2, 
            e => e.Name, 
            e => e.Name, 
            (genre1, genre2) => new Genre 
                { 
                    Name = genre1.Name, 
                    Albums = genre1.Albums.Union(genre2.Albums, new AlbumComarer()).ToList() 
                }
            ).ToList();
        unified.AddRange(list2.Except(list1, new GenreComarer()));
        unified.AddRange(list1.Except(list2, new GenreComarer()));
