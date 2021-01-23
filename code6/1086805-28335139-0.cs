        #region ShirtsComponent Members
        string ShirtsComponent.GetBrand()
        {
            return string.Format("{0}, {1}", fashion_Base.GetBrand(), _brand);
        }
        double ShirtsComponent.GetPrice()
        {
            return _price + fashion_Base.GetPrice();
        }
        #endregion
