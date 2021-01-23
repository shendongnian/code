    // Action can be used as a shorter from of delegate 
    public Action<List<Card>, List<Card>, List<List<Card>>> Effect {
      get;
      set;
    }
    ...
    
    // Function
    private void effect(List<Card> KaibaHand, 
                        List<Card> KaibaDeck, 
                        List<List<Card>> Field) {
      ... 
    }
    ...
    Effect = effect;
    ...
    List<Card> KaibaHand = ... 
    List<Card> KaibaDeck = ...
    List<List<Card>> Field = ...
    
    // If function Effect is specified call it:
    if (!Object.ReferenceEquals(null, Effect)) {
      Effect(KaibaHand, KaibaDeck, Field);
    }
