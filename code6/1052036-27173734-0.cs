    public class GiftClaimService
    {
        private static readonly object Lock = new object();
        private ISomeRepository _someRepository; // Going to be injected or whatever
    
        public bool ClaimGift(int giftId, string myName)
        {
            lock (Lock)
            {
                var gift = _someRepository.Get(giftId);
                if (gift != null && gift.Owner == null)
                {
                    gift.Owner = myName;
                    _someRepository.Save(gift);
                    return true;
                }
                return false;
            }
        }
    }
