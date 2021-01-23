    using System.Collections.ObjectModel;
    public class Appointments : Collection<IAppointment>, IAppointments
    {
        public bool Load()
        {
            return true;
        }
        public bool Save()
        {
            return true;
        }
        public IEnumerable<IAppointment> GetAppointmentsOnDate(DateTime date)
        {
            return new List<IAppointment>();
        }
    }
