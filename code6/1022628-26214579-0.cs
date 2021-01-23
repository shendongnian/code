    query = (from cat in _db.Categories
                     join en in _db.Entries on cat.Id equals en.CategoryId
                     select new ListAllEntriesViewModel
                     {
                         Id = cat.Id,
                         Title = en.Title,
                         Username = en.Username,
                         Password = en.Password,
                         Url = en.Url,
                         Description = en.Description,
                         CategoryName = cat.Name
                     }).AsEnumerable();
