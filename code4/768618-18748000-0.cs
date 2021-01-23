    foreach(var a in aposts.OrderByDescending(p => p.CreatedOn))
    {
        parcels.Add(a);
        parcels.Add(bposts.Where(b => a.ID == b.RecipientID).OrderByDescending(p => p.CreatedOn));
    }
