    var animal = new AnimalContainer { Animal = new Dog { Bark = 5, Width = 2 } };
    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
    var json = JsonConvert.SerializeObject(animal, settings);
    var deserializedAnimal = JsonConvert.DeserializeObject<AnimalContainer>(json, settings);
    Console.WriteLine(deserializedAnimal.Animal.GetType().Name);
