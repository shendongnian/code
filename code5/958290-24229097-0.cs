    protected override void Seed(IQsLab.Models.ApplicationDbContext context)
    {
       Album album1 = new Album { /* ... */ };
       Album album2 = new Album { /* ... */ };
       Album album3 = new Album { /* ... */ };
       
       Song1_1 = new Song { /* ... */ };
       Song1_2 = new Song { /* ... */ };
       Song1_3 = new Song { /* ... */ };
       // ...
       Album1.Songs.Add(Song1_1);
       Album1.Songs.Add(Song1_2);
       Album1.Songs.Add(Song1_3);
       // ...
       context.Albums.Add(Album1);
       context.Albums.Add(Album2);
       context.Albums.Add(Album3);
       // ...
       context.SaveChanges();
     }
