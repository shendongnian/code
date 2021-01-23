    public DataServiceCollection<EquipBooking> FilterJobs(DateTime SeletedDateChanged)
        {
            var items = EquipBookings.Where(c => c.CreatedOn == SeletedDateChanged);
            var dataServiceCollection = new DataServiceCollection<EquipBooking>();
            foreach(var equipBooking in items)
            {
                 dataServiceCollection.Add(equipBooking);
            }
            return dataServiceCollection;
        }
