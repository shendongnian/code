	class TAnimal {
		public TAnimal(string Name) { this.Name = Name; }
		public string Name { get; set; }
	}
    // Constructors cannot be inherited, so we have to implement it (calling
    // the base class constructor) on each one of the derived classes.
	class TElephant : TAnimal { public TElephant(string Name) : base(Name) { } }
	class TEmu : TAnimal { public TEmu(string Name) : base(Name) { } }
	class THovercraft { }
	
	IList<object> Zoo = null;
	
	void PopulateZoo() {
		Zoo = new List<object>();
		AddToZoo<TElephant>("Ellie");
		AddToZoo<TEmu>("Erik");
		AddToZoo<THovercraft>();
	}
	
    // Here, we specify the constraint [class TAnimal] for the type parameter T.
	void AddToZoo<T>(string Name = null) where T: TAnimal {
		T Animal = (T) Activator.CreateInstance(typeof(T), Name);
		Zoo.Add(Animal);
	}
