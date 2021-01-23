    public virtual Fee GetFeeByPromoCode(string promoCode)
    {
        try
        {
            return _fees.SingleOrDefault(f =>
                {
                    try
                    {
                        return f.IsPromoCodeValid(promoCode);
                    }
                    catch(InvalidOperationException)
                    {
                        throw new PromoCodeException();
                    }
                });
        }
        catch (InvalidOperationException)
        {
            throw new TooManyFeesException();
        }
    }
