        int _Age;
        while( true )
        {
            Console.Write ("Please enter your age :") 
            string AgeEntry = Console.ReadLine();
            bool AgeCheck = Int32.TryParse(AgeEntry, out _Age);
            
            if ( AgeCheck == true ) {  break; }
        }
