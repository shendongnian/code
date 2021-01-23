      string firstSwitch = Console.ReadLine().ToLower();
                const string goodbye = "Hello, Goodbye";
                const string gandalf = "YOU SHALL NOT PASS!";
                const string skyrim = "I used to be an adventurer like you, then I took an arrow to the knee.";
                const string otherWise = "The Force is strong with this one.";
                switch (firstSwitch)
                {
                    case "goodbye":
                        Console.WriteLine(goodbye);
                        break;
    
                    case "gandalf":
                        Console.WriteLine(gandalf);
                        break;
    
                    case "skyrim":
                        Console.WriteLine(skyrim);
                        break;
                    case "giveRandom":
                        var dic = new Dictionary<int, string>();
                        dic[0] = goodbye;
                        dic[1] = gandalf;
                        dic[2] = skyrim;
                        var rnd = new Random();
                        Console.WriteLine(dic[rnd.Next(2, 0)]);
                        break;
                    default:
                        Console.WriteLine(otherWise);
                        break;
                }
