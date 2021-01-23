    foreach(var a in aposts.OrderByDescending(p => p.CreatedOn))
    {
        parcels.Add(a);
        foreach(var b in bposts.Where(bpost => bpost.RecipientID == a.ID).OrderByDescending(bpost => bpost.CreatedOn))
        {
            parcels.AddRange(Iterate(b, bposts));
        }
    }
    public IList<Parcel> Iterate(Parcel a, IList<Parcel> b)
    {
        var parcels = new List<Parcel>();
        foreach(var post in b.Where(bpost => a.ID == bpost.RecipientID).OrderByDescending(bpost => bpost.CreatedOn))
        {
            parcels.Add(post);
            parcels.AddRange(Iterate(post, b));
        }
        return parcels;
    }
