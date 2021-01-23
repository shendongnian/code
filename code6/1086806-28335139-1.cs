        #region ShirtsComponent Members
        public string GetBrand()
        {
            return string.Format("{0}, {1}", fashion_Base.GetBrand(), _brand);
        }
        public double GetPrice()
        {
            return _price + fashion_Base.GetPrice();
        }
        #endregion
