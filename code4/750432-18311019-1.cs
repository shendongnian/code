        private Visibility _extraCarDetailsVisibility;
        public Visibility ExtraCarDetailsVisibility
        {
            get
            {
                _extraCarDetailsVisibility= Visibility.Collapsed;
                if (PendingCarSelected != null)
                {
                    var category = CarSelected.CounterpartyCategory.ToLower();
                    if (category == "porsche" || category == "porsches")
                    {
                        _extraCarDetailsVisibility= Visibility.Visible;
                    }
                }
                return _extraCarDetailsVisibility;
            }
            set
            {
                _extraCarDetailsVisibility= value;
                NotifyPropertyChanged("ExtraCarDetailsVisibility");
            }
        }
