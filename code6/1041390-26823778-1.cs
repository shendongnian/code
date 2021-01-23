	string p = prefix ?? "";
	string d = delimiter ?? "";
	var filegroups = from b in folder.GetFiles(data)
						where b.Uri.StartsWith(p) && b.Uri.CompareTo(marker ?? "") >= 0
						group b by data.DataContext.nx_GetFileFolder(p, d, b.Uri);
	var folders = from g in filegroups where g.Key.Length > 0 select g.Key;
	var files = from b in folder.GetFiles(data)
				where b.Uri.StartsWith(p) && b.Uri.CompareTo(marker ?? "") >= 0
					&& data.DataContext.nx_GetFileFolder(p, d, b.Uri).Length == 0
				select b;
			
	folders = folders.OrderBy(f => f).Take(maxresults + 1);
	files = files.OrderBy(f => f.Uri).Take(maxresults + 1);
	var retval = folders.AsEnumerable().Select(f => new FilePrefix { Name = f })
				.Concat(files.AsEnumerable().Select(f => new FilePrefix { Name = f.Uri, Original = f }))
				.OrderBy(b => b.Name).Take(maxresults + 1);
	int count = 0;
	foreach (var bp in retval)
	{
		if (count++ < maxresults)
			yield return bp;
		else
			newmarker.Name = bp.Name;
	}
	yield break;
