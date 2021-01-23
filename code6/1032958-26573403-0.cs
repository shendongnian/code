      public List<Item> GetAll()
        {
            var sql =
                "SELECT * FROM Items;" +
                "SELECT ItemId, Tags.Title FROM ItemTag left join Tags on ItemTag.TagId = Tags.Id;";
            using (var multipleResults = this.db.QueryMultiple(sql))
            {
                var items = multipleResults.Read<Item>().ToList();
                var tags = multipleResults.Read<Tag>().ToList();
                var tagsByItemId = tags.ToLookup(t => t.ItemId);
                foreach (var item in items)
                {
                    item.Tags = tagsByItemId[item.Id].ToList();
                }
                return items;
            }
        }
