    var myPet = new Pet();
    Console.WriteLine("Please write your pet's name");
    myPet.Name = Console.ReadLine();
    Console.WriteLine("The type of animal your pet is:");
    myPet.Type = Console.ReadLine();
    DateTime dateOfBirth;
    string line;
    do
    {
        Console.WriteLine("The date of birth of your pet:");
        line = Console.ReadLine();
    } while(DateTime.TryParse(line, out dateOfBirth);
    myPet.DateOfBirth = dateOfBirth;
    Console.WriteLine("The name of your pet is:", myPet.Name);
    Console.WriteLine("The type of animal your pet is: ", myPet.Type);
    Console.WriteLine("The age of your pet is:", GetAge(myPet.DateOfBirth));
