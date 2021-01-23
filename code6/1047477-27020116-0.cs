	void Main()
	{
		var apps = new NameVersion[]
		{
			new NameVersion {name="Adobe", version=1},
			new NameVersion {name="Adobe", version=2},
			new NameVersion {name="Adobe", version=3},
			new NameVersion {name="VLC", version=1},
			new NameVersion {name="VLC", version=2},
			new NameVersion {name="VLC", version=3}
		};
		
	
		var q = from a in apps
				group a by a.name into g
				select new NameVersion { name=g.Key, version = g.Max(a=> a.version)};
	
		q.Dump();
	}
