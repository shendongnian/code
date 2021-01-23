    using (var db = new ChildContext())
    {
        // get the id of the selected child
        var childId = (ChildrenGrid.SelectedItem as Child).ChildId;
        // pull that record from the "live" context
        Child entity = db.Child.Single(x => x.ChildId == childId);
        // add the new record to the "live" entity
        entity.Registers.Add(new Register
        {
            dt_in = DateTime.Now,
            dt_out = DateTime.Now
        });
        db.SaveChanges();
    }
