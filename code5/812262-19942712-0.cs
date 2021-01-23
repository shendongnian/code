    void Main()
    {
	using (var writer = new FileStream("dog.xml", FileMode.Create, FileAccess.Write))
	{
		var savedog = new Dog();
		savedog.Breed = "Boxer";
		savedog.Weight = 95;
		var serializer = new DataContractSerializer(typeof(Dog));
		serializer.WriteObject(writer, savedog);
	}
	
	using (var reader = new FileStream("dog.xml", FileMode.Open, FileAccess.Read))
	{
		var serializer = new DataContractSerializer(typeof(Dog));
		var recalldog = (Dog)serializer.ReadObject(reader);
		Console.WriteLine(recalldog.Breed);
		Console.WriteLine(recalldog.Weight);
	}	
    }
    public class Dog
    {
	public string Breed { get; set; }
	public int Weight { get; set; }
    }
