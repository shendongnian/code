	private void AI()
	{
		if (ccs.All(cc => cc == false))
		{
			throw new System.InvalidOperationException("All `ccs` are false");
		}
		int aimove = -1;
		do
		{
			aimove = rnd.Next(0, 7);
			CheckIfValid();
		} while (ccs[aimove] == false);
		cs[aimove]++;
		Drop(aimove);
	}
