    public void ConScen3(bool hasEncountered)
        {
            string pokemon1 = "pikachu";
            TextAdventure1.ConjoinedScenarios.ConjoinedScenario conScen = new TextAdventure1.ConjoinedScenarios.ConjoinedScenario();
            if (hasEncountered == false)
            {
                Console.WriteLine("While travelling you go through a patch of tall grass..");
                Thread.Sleep(2000);
                Console.WriteLine("*pokemon music*");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("You encounter a {0}!", pokemon1);
            }
            else
            {
                Console.WriteLine(" < {0} >", pokemon1);
            }
        }
