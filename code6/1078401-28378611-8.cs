	private void AI()
	{
		Random rnd = new Random();
		int aimove = rnd.Next(0, 7);
		CheckIfValid();
		if (ccs.All(cc => cc == false))
		{
			throw new System.InvalidOperationException("All `ccs` are false");
		}
		if (ccs[aimove] == false)
		{
			AI();
		}
		else
		{
			cs[aimove]++;
			Drop(aimove);
		}
	}
