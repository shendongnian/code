	private void Awake()
	{
		DontDestroyOnLoad(this);
		m_Instance = this;
		var shader = Shader.Find("Unlit Transparent Vertex Colored"); // <= it's some kind of best practise to put shaders in separate files, and load them like this
		m_Material = new Material(shader);
	}
