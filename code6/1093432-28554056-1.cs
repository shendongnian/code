	void Person_PropertyChanged(object sender, PropertyChangedEventArgs e){
		switch (e.PropertyName)
		{
			case ToPropertyName(() => Person.Color);
				//some stuff
				break;
			default:
				break;
		}
	}
