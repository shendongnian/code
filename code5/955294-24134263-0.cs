    public bool IsStraightFlush(IHand hand)
    {
       var sortedCards = from c in hand.Cards
    					 group c by c.Suit into d			  
    					 select new
    					 {
    						Suit = d.Key,
    						Cards = d.OrderBy(x => x.Face)
    					 };
    					
    	// all cards are the same suit				
    	if(sortedCards.Count() == 1)
    	{
    		Card previousCard = null;
    		foreach (var card in sortedCards.First().Cards)
    		{
    			if(previousCard != null && (card.Face - previousCard.Face > 1))
    			{
    				return false;
    			}
    			
    			previousCard = card;
    		}
    		
    		return true;
    	}
       
       return false;
    }
    
    void Main()
    {
    	var hand = new Hand 
    	{
    		Cards = new List<Card>
    		{
    			new Card { Face = CardFace.Two, Suit = CardSuit.Clubs },
    			new Card { Face = CardFace.Three, Suit = CardSuit.Clubs },
    			new Card { Face = CardFace.Four, Suit = CardSuit.Clubs },
    			new Card { Face = CardFace.Five, Suit = CardSuit.Clubs },
    			new Card { Face = CardFace.Six, Suit = CardSuit.Clubs },
    		}
    	};
    	
    	Console.WriteLine(IsStraightFlush(hand));
    	
    }
