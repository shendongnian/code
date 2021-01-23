    class Card
    {
        //void effect(List<Card> KaibaHand, List<Card> KaibaDeck, List< List<Card> > Field);   
    
        public delegate void DelEffect(List<Card> KaibaHand, List<Card> KaibaDeck, List<List<Card>> Field);
    
        // delegate property is strange but should work here
        public DelEffect EffectDelegate
        {
            get { return effect; }
            set { effect = value; }
        }
        // probably better:
        public event DelEffect EffectEvent;
    }
