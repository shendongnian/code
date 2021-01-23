        public virtual Fee GetFeeByPromoCode(string promoCode)
        {
            try
            {
                return _fees.ExactlyOneOrZero(f => f.IsPromoCodeValid(promoCode));
            }
            catch (TooManyMatchesException)
            {
                throw new TooManyFeesException();
            }
        }
