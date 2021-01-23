	void computePayoffs(GameState state, int[] possiblePayoffs,
		IEnumerable<int> values, int numStrokes)
	{
		if (numStrokes == 0)
		{
			// Populate possiblePayoffs[]
		}
		else
		{
			for (int i = 0; i <= 5; i++)
			{
				state.colors[i]++;
				computePayoffs(
						state,
						possiblePayoffs,
						values.Concat(new [] { i }),
						numStrokes - 1);
				state.colors[i]--;
			}
		}
	}
