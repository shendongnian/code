    var sorted = new List<Guest>();
	var guestvips = from g in guests
					from v in vips.Where(vip => vip.FirstName == g.FirstName && vip.LastName == g.LastName).DefaultIfEmpty()
					where v != null
					select g;
	var guestsimple = from g in guests
					  from v in vips.Where(vip => vip.FirstName == g.FirstName && vip.LastName == g.LastName).DefaultIfEmpty()
					  where v == null
					  select g;
	sorted.AddRange(guestvips.Concat(guestsimple));
