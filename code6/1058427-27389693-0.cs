    char guestlist;
    ArrayList Guest1 = new ArrayList();
    ArrayList Guest2 = new ArrayList();
    ArrayList Guest3 = new ArrayList();
    
    Console.WriteLine("Thank you for dining with us.");
    
    // Create a path to the My Documents folder and the file name
    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocum
                                Path.DirectorySeparatorChar + "Food.txt";
    
    // Read the contents of the file using ReadAllLines
    Console.WriteLine("Please assign each item a guest number");
    string[] contents = File.ReadAllLines(filePath);
    foreach (string s in contents)
    {
        Console.WriteLine(s);
        guestlist = (char)Console.Read();
    
        switch (guestlist)
        {
            case '1':
                //Add to a guest1 array
                Guest1.Add(s);
                Console.WriteLine("{0} has been added to Guest1", s);
                break;
            case '2':
                //Add to a guest2 array
                Guest2.Add(s);
                Console.WriteLine("{0} has been added to Guest2", s);
                break;
            case '3':
                //Add to a guest3 array
                Guest3.Add(s);
                Console.WriteLine("{0} has been added to Guest3", s);
                break;
            default:
                //Add to default array
                Console.WriteLine("Default has been used");
                break;
