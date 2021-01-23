     string input = "23 + 323 = 346";
     
     string[] sides = input.Split('=');
     string[] operands;
     int answer = 0;
     if (sides.Length == 2)
     {
          if (sides[0].Contains('+'))
          {
              operands = sides[0].Split('+');
              operands[0].Trim();
              operands[1].Trim();
              answer = int.Parse(operands[0]) + int.Parse(operands[1]);
              // note if you're serious about error handling use tryparse to ensure the values are integers
              if (answer != int.Parse(sides[1].Trim()))
                 // answer is wrong
          }
          else if (sides[0].Contains('-'))
          {
              // same logic
          }
     }
     else
          //input formatting error
