    void Main()
    {
    	var s = new GiftClaimService ();
    	s.ClaimGift(1,"Me");
    }
    
    public class Gift
    {
       public int Id { get; set; }
       public string Owner { get; set; }
    }
    public interface ISomeRepository
    {
    	Gift Get(int giftId);
    	void Save(Gift gift);
    }
    public class GiftClaimService
    {
        private ISomeRepository _someRepository; // Going to be injected or whatever
       public readonly static Dictionary<int, string> _claimsInProgress = new Dictionary<int, string>();
       private static readonly object _locker = new object();
    
        public bool ClaimGift(int giftId, string myName)
        {
    		lock (_locker)
    		{
    		if ( _claimsInProgress.ContainsKey(giftId))
    			return false;
    		}
    		
            var gift = _someRepository.Get(giftId);
    		if (gift == null)
    			return false; // no such gift
    		
    		lock (_locker)
    		{
    			if ( _claimsInProgress.ContainsKey(giftId))
    				return false;// someone claimed it just now
    				
    			_claimsInProgress.Add(giftId, myName);
    		}
    		bool retValue;
            if (gift.Owner == null)
            {
                gift.Owner = myName;
                _someRepository.Save(gift);
                retValue = true;
            }
    		else
    			retValue = false;
    		
    		lock (_locker)
    		{
    			_claimsInProgress.Remove(giftId);
    		}			
    			
            return retValue;
        }
    }
