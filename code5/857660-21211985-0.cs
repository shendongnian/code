    while(true){
        try{
            Console.WriteLine("Please Choose a Drink; Press 1 for Coke, Press 2 for Sprite, Press 3 for Dr.Prpper");
            switch(int.Parse(Console.ReadLine())){
                case 1:
                    //do coke
                    break;
                case 2:
                    //do sprite
                    break;
                case 3:
                    //do dr pepper
                    break;
                default:
                    //your message is shown if no matching rules were found, not based on a secondry range check
                    Console.WriteLine("Im not sure what to do with that option");
                    break;    
            }
        }
        //be explicit about the exceptions you want to catch
        catch(FormatException){
            Console.WriteLine("What you entered wasnt a number");
        }
    }
