using (YourContext db = new YourContext())
{
    var foundList=db.YourDbSet.Where(c=>c.YourProp=='someVal').ToList();
    db.YourDbSet.RemoveRange(foundList);
    db.SaveChanges();
}
**Summary**:
    >Removes the given collection of entities from the context underlying the set
    with each entity being put into the Deleted state such that it will be deleted
    from the database when SaveChanges is called.
**Remarks**:
    >Note that if System.Data.Entity.Infrastructure.DbContextConfiguration.AutoDetectChangesEnabled
    is set to true (which is the default), then DetectChanges will be called once
    before delete any entities and will not be called again. This means that in some
    situations RemoveRange may perform significantly better than calling Remove multiple
    times would do. Note that if any entity exists in the context in the Added state,
    then this method will cause it to be detached from the context. This is because
    an Added entity is assumed not to exist in the database such that trying to delete
    it does not make sense.
