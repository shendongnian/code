    var queryResult = (from x in xmlDocument.Root.Element("Worker").Elements() select x).ToList();
    Console.WriteLine("Start reading <ID> element");
    Console.WriteLine("Contains: " + queryResult[0]);
    Console.WriteLine("Start reading <FirstName> element");
    Console.WriteLine("Contains: " + queryResult[1]);
    Console.WriteLine("Start reading <LastName> element");
    Console.WriteLine("Contains: " + queryResult[2]);
    Console.WriteLine("Start reading <Salary> element");
    Console.WriteLine("Contains: " + queryResult[3]);
