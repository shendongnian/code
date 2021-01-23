    var lookup = associations.ToLookup(pf => pf.ParkID, pf => facilities.Single(f => f.ID == pf.FacilityID));
    Park[] parks = new Park[]{
        new Park() {ID = 1, Name = "Free Park", Facilities = lookup[1].ToArray()},
        new Park() {ID = 2, Name = "Cost Park", Facilities = lookup[2].ToArray()},
        new Park() {ID = 3, Name="Sneak in Park", Facilities = lookup[3].ToArray()}
    };
