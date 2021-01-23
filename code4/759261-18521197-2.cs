        public View2ViewModel(IChildView i, IRepository r)
        {
            int CarId;
            r.GetCarId((id) => CarId = id);
            thisCar = GetCarFromDatabase(CarId);
        }
    
