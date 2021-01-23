		public ObservableCollection<Person> NamesList { get; set; }
		public Person() {
			Person p = new Person("Piet", "Male");
			Person p2 = new Person("Pietin", "Female");
			NamesList = new ObservableCollection<Person>();
			NamesList.Add(p);
			NamesList.Add(p2);
		}
		public Person(string Name, string Gender){
			m_name = Name;
			m_gender = Gender;
		}
