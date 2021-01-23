	private void AI()
	{
		Random rnd = new Random();
		int aimove = rnd.Next(0, 7);
		CheckIfValid();
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
