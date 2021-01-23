    protected override BuyerDeal Map(BuyerDealDTO buyerDealDTO, BuyerDeal buyerDealEntity)
    {            
        ExtraLogic(...);
        base.Map(buyerDealDTO, buyerDealEntity);
        return buyerDealEntity;
    }
    
    protected vodi ExtraLogic(...)
    {
        buyerDealEntity.prop1 = buyerDealDTO.prop2;
    }
