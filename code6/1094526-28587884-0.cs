    // Remove items that are no longer related
    entity.SomeM2MNavigationProperty.Where(m => !newRelationshipItemIds.Contains(m.Id))
        .ToList().ForEach(m => entity.SomeM2MNavigationProperty.Remove(m));
    // Then you need to add any new relationships
    var existingRelationshipItemIds = entity.SomeM2MNavigationProperty.Select(m => m.Id).ToList();
    db.EntityDbSet.Where(m => newRelationshipItemIds.Except(existingRelationshipItemIds).Contains(m.Id))
        .ToList().ForEach(m => entity.SomeM2MNavigationProperty.Add(m));
