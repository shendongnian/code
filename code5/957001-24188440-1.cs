    DbImageModel imageAfter = ctx.Images.Include(i => i.Application)
        .OrderBy(i => i.ImageId)
        .FirstOrDefault(i => i.ImageId > image.ImageId);
    DbImageModel imageBefore = ctx.Images.Include(i => i.Application)
        .OrderByDescending(i => i.ImageId)
        .FirstOrDefault(i => i.ImageId < image.ImageId);
