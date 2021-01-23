    public interface IApts
    {
        bool Load();
        bool Save();
        void Add(IApt appointment);
        IEnumerable<IApt> GetAptsOnDate(DateTime date);
    }
    class Apts: IApts
    {
        private List<IApt> myAppointments = new List<IApt>();
       
        public void Add(IApt appointment)
        {
            this.myAppointments.Add(appointment);
        }
        // rest of class omitted for brevity
    }
