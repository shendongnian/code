    const int ChunkSize = 100;
    for(int i = 0; i < numberOfLines; i += ChunkSize)
    {
        using(Context context = new Context())
        {
            for(int j = i; j < i + ChunkSize && j < numberOfLines; j++)
            {
                // if needed, use j within this loop, not i
                context.Collection.AddObject(line);
            }
            context.SaveChanges()
         }
    }
