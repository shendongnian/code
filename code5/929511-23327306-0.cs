    public interface IAppointments
    {
        IList<IAppointment> TheAppointments { get; }
        bool Load();
        bool Save();
        IEnumerable<IAppointment> GetAppointmentsOnDate(DateTime date);
    }
