    public abstract class MyBaseClass
    {
        public BuyerDeal Map(BuyerDealDTO buyerDealDTO, BuyerDeal buyerDealEntity)
        {
            // perform base class logic here
            var entity = this.MapInternal(buyerDealDTO, buyerDealEntity);
            return entity;
        }
        protected abstract BuyerDeal MapInternal(BuyerDealDTO buyerDealDTO, BuyerDeal buyerDealEntity);
    }
    public class MyClass : MyBaseClass
    {
        protected override BuyerDeal MapInternal(BuyerDealDTO buyerDealDTO, BuyerDeal buyerDealEntity)
        {            
            buyerDealEntity.prop1 = buyerDealDTO.prop2;
            return buyerDealEntity;
        }
    }
