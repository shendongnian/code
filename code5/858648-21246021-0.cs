    public void throwPoint(int result) {
       while(true)
       {
          int a = throw2Dice();
           if (a == result) {
               Console.WriteLine ("You rolled the same score! You win!");
               break;
           } else if (a == 7) {
              Console.WriteLine ("You rolled a 7! You loose!");
              break;
          } else {
            Console.WriteLine ("You rolled a " + a + ". Rolling again!");
        }
      }
    }
