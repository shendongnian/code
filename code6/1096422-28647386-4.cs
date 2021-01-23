            var books = 
                JObject.Parse(json).Descendants()
                    .OfType<JProperty>()
                    .Where(p => p.Name == "values")
                    .Select(p => p.Value.ToObject<List<KeyValuePair<string, string>>>())
                    .Select(values => new Book { Name = values.Find(v => v.Key == "name").Value, BookId = values.Find(v => v.Key == "bookid").Value })
                    .ToList();
