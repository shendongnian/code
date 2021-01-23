    /// <summary>
	/// Changes the material attached to the gameObject
	/// </summary>
	public static void ChangeMaterial(this GameObject go, Material mat)
	{
		go.renderer.material = mat;
	}
			
	/// <summary>
	/// Changes the color of the material
	/// </summary>
	public static void ChangeColor(this Material mat, Color color)
	{
		mat.SetColor("_Color", color);				
	}
