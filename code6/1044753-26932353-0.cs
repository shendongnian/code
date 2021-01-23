            switch (e.Result.Text.ToUpperInvariant())
            {
                case "ADD":
                   lblText.Content = "Adding"; 
                     int currNum = UserInput; //Have UserInput stored elsewhere and
                                              //loop to increment the value.
                     
                     for(int i = 0; i < k; i++)
                       {
                         int plus = 5;
                         currNum = currNum++;
                         currNum + plus; 
                       }
                     return currNum;
                    break;
                default;
            }
