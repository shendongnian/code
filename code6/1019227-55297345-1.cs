        public static void TestMethod(string promoCode)
        {
            List<Fee> promoCodes = new List<Fee>();
            // moreThanOneMatchMessage = "Duplicate Promo codes detected" and retur null for no codes
            promoCodes
                .Where(f => f.IsPromoCodeValid(promoCode))
                .SingleOrDefault(moreThanOneMatchMessage:"Duplicate Promo codes detected");
            // OR noElementsMessage = "There is no Promotion codes configured" and moreThanOneMatchMessage = "Duplicate Promo codes!!"
            // This extention was not included in the code section, wanted to keep response small however show this extention, same concept as SingleOrDefault extention
            promoCodes
                .Where(f => f.IsPromoCodeValid(promoCode))
                .Single(moreThanOneMatchMessage:"Duplicate Promo codes!!", noElementsMessage:"There is no Promotion codes configured");
            // Lets Customeze the exception type, TooManyFeesException thrown with a message "Duplicate Promo codes!!"
            // AND if there are no items a InvlaidArgumentException with message "There is no Promotion codes configured"
            promoCodes
                .Where(f => f.IsPromoCodeValid(promoCode))
                .SingleOrDefault<Fee, TooManyFeesException>("There is no Promotion codes configured", "Duplicate Promo codes!!");
        }
