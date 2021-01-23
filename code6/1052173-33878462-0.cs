    protected void UpdateChildCollection<Tparent, Tid , Tchild>(Tparent dbItem, Tparent newItem, Func<Tparent, IEnumerable<Tchild>> selector, Func<Tchild, Tid> idSelector) where Tchild : class
        {
            var dbItems = selector(dbItem).ToList();
            var newItems = selector(newItem).ToList();
            if (dbItems == null && newItems == null)
                return;
            var original = dbItems?.ToDictionary(idSelector) ?? new Dictionary<Tid, Tchild>();
            var updated = newItems?.ToDictionary(idSelector) ?? new Dictionary<Tid, Tchild>();
            var toRemove = original.Where(i => !updated.ContainsKey(i.Key)).ToArray();
            var removed = toRemove.Select(i => DbContext.Entry(i.Value).State = EntityState.Deleted).ToArray();
            var toUpdate = original.Where(i => updated.ContainsKey(i.Key)).ToList();
            toUpdate.ForEach(i => DbContext.Entry(i.Value).CurrentValues.SetValues(updated[i.Key]));
            var toAdd = updated.Where(i => !original.ContainsKey(i.Key)).ToList();
            toAdd.ForEach(i => DbContext.Set<Tchild>().Add(i.Value));
        }
