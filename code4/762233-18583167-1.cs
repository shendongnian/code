    public void Check(int[] numbers, int Token) {
       for (int i = 0; i < numbers.Length; i++) {
           if ( Token > numbers[i]) {
              Console.WriteLine("You Got To Wait");
              return;
           }
        }
    }
    public static void Main() {
        int[] numbers = new int[] {1, 2};
        int[] tokens = new int[] {1,2,3,4,5};
        Random rnd = new Random();
        int r = rnd.Next(tokens.Length);
        int Token = (tokens[r]);
        Tollgate T = new TollGate();  
        T.Check(numbers, Token); 
    }
