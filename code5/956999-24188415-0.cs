    using (UsersDbContext ctx = new UsersDbContext())
    {
        try
        {
            DbImageModel image = ctx.Images.Include(i => i.Application)
                  .OrderBy(c => c.ImageId)
                  .FirstOrDefault(s => s.ImageTag == imageTag);
    
            DbImageModel previousImage = ctx.Images.OrderBy(c => c.ImageId)
                  .FirstOrDefault(s => s.ImageId < image.ImageId);
            DbImageModel nextImage = ctx.Images.OrderBy(c => c.ImageId)
                  .FirstOrDefault(s => s.ImageId > image.ImageId);
    
            // Do something with image(s)
    
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();  // For debugging
        }
    }
