    public IEnumerable<int> Generator(int max){
       for(var i=0; i< max; i++){
          yield return someExpensiveFunction();
       }
    }
