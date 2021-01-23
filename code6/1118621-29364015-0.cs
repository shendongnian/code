    var imagesGrouped = dbContext.ImageGroupImages
                                 .Include("Image") // include image nav property
                                                   // if lazy loading is on                                 
                                 .GroupBy(imgGr => imgGr.ImageGroupId)
                                 .ToList();
    
    foreach (var group in imagesGrouped)
    {
       Console.WritLine("group: {0}, images: {1}",
                        group.Key,
                        string.Join(",", group.Select(img => img.Id)));
    }
