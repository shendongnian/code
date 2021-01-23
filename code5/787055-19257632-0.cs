    string[] stringArray = File.ReadAllLines("Name.txt");
    for (int i = 0;i <=stringArray.Length;i++){
            Console.WriteLine(stringArray[i]);
        }
    Console.WriteLine("Please enter a name to add to the list.");
    var name = Console.ReadLine();
    File.AppendLine("Name.txt", name):
