    do
    {
        Console.WriteLine("Do you want to continue - Yes or No");
        choice = Console.ReadLine(); 
        if(choice.ToUpper() != "NO" && choice.ToUpper() != "NO");
        {
            Console.WriteLine("ERROR INVALID INPUT: Only input Yes or No!");            
        }
    } while(choice.ToUpper() != "YES" && choice.ToUpper() != "NO");
