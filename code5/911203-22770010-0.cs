    var step1 = db.BLOGS_MESSAGES
                  .Where(...)
                  .Select(message => new {
                      Authors = message.AUTHORS.Select(a => a.USERS), // No .ToArray()
                      ...
                  }).ToList();
    var step2 = step1.Select(message => New BlogMessage {
                    Authors = message.Authors.ToArray(),
                    ...
                }).ToList();
