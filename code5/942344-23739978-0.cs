    private void AddNewReservation()
        {
            var res = new Reservation();
            var rvm = new ReservationViewModel(res);
            Reservations.Add(rvm);
            rvm.DeleteCommand = new RelayCommand(
                param =>
                {
                    Reservations = new ObservableCollection<ReservationViewModel>(Reservations.Where(r => r != rvm));
                });
            rvm.PropertyChanged += (sender, args) => SaveReservation(res, rvm);
        }
