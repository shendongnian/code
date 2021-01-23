        #region ShirtsComponent Members
        public override string GetBrand()
        {
            return string.Format("{0}, {1}", fashion_Base.GetBrand(), _brand);
        }
        public override double GetPrice()
        {
            return _price + fashion_Base.GetPrice();
        }
        #endregion
