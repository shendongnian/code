    XElement lecturelist = XElement.Load("lecturer.xml");
    Console.WriteLine("Select a lecturer:");
    
    String strProf;
    Int i = 1;
    
    
    foreach (var mainelement in lecturelist.Elements())
        {
            Console.Write(i.ToString() + " - ");
            foreach (var subelement in mainelement.Elements())
                {
                    
                    if (subelement.Name == "Name")
                    {
                        Console.Write("Lecturer: {0}", subelement.Value);
                                                      
                    }
                    if (subelement.Name == "Surname")
                        Console.Write(", {0}", subelement.Value);
                    if (subelement.Name == "Specialisation")
                        Console.Write(" Subject: {0} \n", subelement.Value);
                   
                    i++;
                }
        }
    \\ somewhere after this is where you read in the answer given by the user
