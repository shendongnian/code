    public static SelectList GetNonRacingHorses(int id, int raceId)
	{
		HorseTracker entities = new HorseTracker();
		var race = entities.Races.Single(r => r.Id == raceId);
		var racehorses = from h in race.RacingHorses
						 select h.Id;
		var userhorses = (from h in entities.Horses
						  where
							  h.UserId == id
						  orderby h.Name
						  select h);
		var nonracinghorses = from h in userhorses
							  where !racehorses.Contains(h.Id)
							select h;
		List<SelectListItem> sli = new List<SelectListItem>();
		foreach (Horse horse in nonracinghorses)
		{
			sli.Add(new SelectListItem { Text = horse.Name, Value = horse.Id.ToString(), Selected = false});
		}
		return new SelectList(sli, "Value", "Text");
	}
