	public static void DisplayMatchResults(Match match)
	{
		Console.WriteLine("Match has {0} captures", match.Captures.Count);
		int groupNo = 0;
		foreach (Group mm in match.Groups)
		{
			Console.WriteLine("  Group {0,2} has {1,2} captures '{2}'", groupNo, mm.Captures.Count, mm.Value);
			int captureNo = 0;
			foreach (Capture cc in mm.Captures)
			{
				Console.WriteLine("       Capture {0,2} '{1}'", captureNo, cc);
				captureNo++;
			}
			groupNo++;
		}
		groupNo = 0;
		foreach (Group mm in match.Groups)
		{
			Console.WriteLine("    match.Groups[{0}].Value == \"{1}\"", groupNo, match.Groups[groupNo].Value); //**
			groupNo++;
		}
		groupNo = 0;
		foreach (Group mm in match.Groups)
		{
			int captureNo = 0;
			foreach (Capture cc in mm.Captures)
			{
				Console.WriteLine("    match.Groups[{0}].Captures[{1}].Value == \"{2}\"", groupNo, captureNo, match.Groups[groupNo].Captures[captureNo].Value); //**
				captureNo++;
			}
			groupNo++;
		}
	}
