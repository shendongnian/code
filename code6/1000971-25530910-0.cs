    public IEnumerable<int> Generator(int max){
       for(int i=0; i< max; i++){
          yield return someExpensiveFunction();
       }
    }
