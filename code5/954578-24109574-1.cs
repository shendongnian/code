    using (UsersDbContext ctx = new UsersDbContext())
    {
        DbImageModel image = ctx.Images.Include(i => i.Applications)
                                .FirstOrDefault(s => s.ImageTag == imageTag);
        if (image != null)        
            return image;        
    }
