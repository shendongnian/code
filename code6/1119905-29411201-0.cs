	private void Button1_Click()
	{
		var toActivate = new[] { 3, 7, 8 };
		ActivateGameObjects(toActivate);
	}
	
	private void Button2_Click()
	{
		var toActivate = new[] { 0, 7 };
		ActivateGameObjects(toActivate);
	}
	
	private void ActivateGameObjects(int[] toActivate)
	{
		for (int i = 0; i < gameobjects.Length; i++)
		{
			gameobjects[i].SetActive(toActivate.Contains(i));
		}
	}
