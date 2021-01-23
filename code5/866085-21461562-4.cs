        public void Apply(AppointmentCreatedFact fact)
        {
            Id = fact.Id;
            DateOfAppointment = fact.DateOfAppointment;
        }
