        private IList<Product> _Items;
        public IList<Product> Items {
            get {
                if (_Items == null) {
                    _Items = DbHelper.CurrentDb().Fetch<Product>("SELECT ..");
                }
                return _Items;
            }
            set {
                _Items = value;
            }
        }
