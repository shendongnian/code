            public void UpdateEntity(MyEntity myEntity, ICollection<int> ids)
            {
                var item = _context.Entry(myEntity);
                item.State = EntityState.Modified;
                item.Collection(x => x.RelatedEntities).Load();
                myEntity.RelatedEntities.Clear();
                foreach (var id in ids)
                {
                    myEntity.RelatedEntities.Add(_context.RelatedEntities.Find(id));
                }
                _context.SaveChanges();
            }
