        public virtual User CheckoutUser
        {
            get { return checkoutUser; }
            set
            {
                if (value != null || !LazyPropertyIsNull(CheckoutUser))
                {
                    checkoutUser = value;
                }
            }
        }
