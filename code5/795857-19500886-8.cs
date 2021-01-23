    public static void ChangeColor(GameObject[] gameObjects, Color color)
	{
		foreach(GameObject gameObject in GameObjects)
		{
			gameObject.renderer.material.ChangeColor( "Your Color" );
		}
	}
