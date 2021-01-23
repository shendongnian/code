    var f = product.Status == ProductStatusEnum.Presale
       ? new Func<Sku, User, CustomPrice>(pricingHelper.GetUserPresalePricing)
       : pricingHelper.GetUserProductPricing;
    
    decimal userPrice = f(user, price).UserCustomPrice;
