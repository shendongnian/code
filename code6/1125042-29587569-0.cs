	public override bool Equals(object obj)
	{
		var person = (Person)obj;
		return Equals(Id, person.Id);
	}
	
	public override int GetHashCode()
	{
		return Id;
	}
