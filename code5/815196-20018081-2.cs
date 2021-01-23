    public DataServiceCollection<EquipBooking> FilterJobs(DateTime SeletedDateChanged)
        {
            var equipBookings = EquipBookings.Where(c => c.CreatedOn == SeletedDateChanged);
            var dataServiceCollection = new DataServiceCollection<EquipBooking>(equipBookings);
           
            return dataServiceCollection;
        }
