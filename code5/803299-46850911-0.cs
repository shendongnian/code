    Dictionary<string, TimeZoneInfo> GetIsoToTimeZoneMapping()
	{
		var source = TzdbDateTimeZoneSource.Default;
		return source.WindowsMapping.MapZones
			.GroupBy(z => z.Territory)
			.ToDictionary(grp => grp.Key, grp => GetTimeZone(source, grp));
	}
	 TimeZoneInfo GetTimeZone(TzdbDateTimeZoneSource source, IEnumerable<MapZone> territoryLocations)
	{
		var result = territoryLocations
			.Select(l => l.WindowsId)
			.Select(TimeZoneInfo.FindSystemTimeZoneById)
			//pick timezone with the minimum offset
			.Aggregate((tz1, tz2) => tz1.BaseUtcOffset < tz2.BaseUtcOffset ? tz1 : tz2);
		return result;
	}
