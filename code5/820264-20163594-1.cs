            bool found = false;
            foreach (Listing item in items)
            {
                if (userSelection == item.GetName())
                {
                    Console.WriteLine("You selected: " + userSelection +
                                "\nWhich Means: " + item.GetDefinition());
                    found = true;
                    break;
                }
            }
            if (!found)
            { Console.WriteLine("I'm sorry, I don't have a match for that."); }
