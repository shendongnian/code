	InitializeComponent();
	var mac = new Macierz(100,40);
	//fill with test data
	for (int i = 0; i < mac.A; i++)
	{
		for (int j = 0; j < mac.B; j++)
		{
			mac[i, j].Data = string.Format("{0}...{1}", i, j);
		}
	}
	//set DataContext
	this.DataContext = mac;
