        List<Parcel> parcels = new List<Parcels>();
        var replies = bposts.ToDictionary(u => u.RecipientID);
        foreach (var p in aparcels)
        {
            parcels.Add(p);
            Parcel parent = p;
            while (replies.TryGetValue(parent.Id, out parent))
            {
                parcels.Add(parent);
            }
        }
