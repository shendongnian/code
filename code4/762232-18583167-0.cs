    public void Check(int[] numbers, int Token) {
       for (int i = 0; i < numbers.Length; i++) {
           if ( Token > numbers[i]) {
              Console.WriteLine("You Got To Wait");
              return;
           }
        }
    }
