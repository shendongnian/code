        int[] userInput = new int[1000];
        int counter;
        Console.WriteLine ("Please input some numbers");
        for (counter = 0; counter < userInput.Length; counter++) {
            string line = Console.ReadLine ();
            if (line == "" || line == "stop") {
                break;
            } else {
                int.TryParse (line, out userInput [counter]);
            }
        }
        var min = userinput.Length>0?userInput[0]:0;
        for(int i = 1; i < userInput.Length; i++)
        {
            if(userInput[i] < min && userInput[i] > 0)
            {
                min = userInput [i];
            }
        }
