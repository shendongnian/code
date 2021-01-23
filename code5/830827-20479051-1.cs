    using (var context = new MyContext())
    {
        try
        {
            var tag = "S";
            var sequence = context.TaggedSequence.Single(s => s.Tag == tag);
            sequence.Last += 1;
            Technology technology = new Technology { ... };
            technology.Id = tag + sequence.Last;
            context.Technologies.Add(technology);
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Retry
        }
    }
 
