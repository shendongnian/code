      int min = 0;
      if(userInput.length >= 0)
      {
        //initilize the minValue with the first input value
        min = userInput[0];
        //compare with the others values and update the min value
        for(int i = 1; i < userInput.Length; i++){
          if(userInput[i] > 0 && userInput[i] < min)
            min = userInput[i];
        }
      }
      Console.WriteLine(min);
