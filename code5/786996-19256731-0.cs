       public static void Main(String[] args)
                {
                    //variable declation
                    string name, race;
                    double age, weight;
                   
                    //variable assigned user inputs
                    Console.Write("Please enter your dog's name: ");
                    name = Console.ReadLine();
                    Console.Write("Please enter your dog's race: ");
                    race = Console.ReadLine();
                    Console.Write("Please enter your dog's age: ");
                    age = double.Parse(Console.ReadLine());
                    Console.Write("Please enter your dog's weight: ");
                    weight = double.Parse(Console.ReadLine());
                    
                    // call of the overloaded constructor with the right parameters
                    Animal dog2 = new Animal(name,race,age,weight);
    
                    dog2.info(); 
    
    
                } 
