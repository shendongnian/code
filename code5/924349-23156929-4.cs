    public ObservableCollection<Equipa> Equipas { get; set; }
    
    void GM_LerEquipasCompleted(object sender, GameManager.LerEquipasCompletedEventArgs e)
    {
    	XDocument data = XDocument.Load(new StringReader(e.Result));
    	var equipas = from query in data.Descendants("Equipas")
    				  select new Equipa
    				  {
    					  ID = (int)query.Element("ID"),
    					  Designacao = (string)query.Element("Designacao"),
    				  };
    	Equipas = new ObservableCollection<Equipa>(equipas);
    	lstbEquipas.ItemsSource = Equipas;
    }
