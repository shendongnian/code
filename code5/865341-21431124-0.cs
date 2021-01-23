    outerJoin = books.GroupJoin(publishers, 
                                b => b.PublisherName, 
                                p => p.Name, 
                                (b, publisherGroup) => new { b.Title, publisherGroup})
                     .SelectMany(x => x.publisherGroup.DefaultIfEmpty(), 
                                (x, y) => new {x.Title, PublisherName = (y == null ? "No publisher" : y.Name)});
