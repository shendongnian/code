    public partial class detail : Window
    {
        private Employee employee;
        public detail(Employee employee)
        {
            this.employee = employee;
            ...
        }
        private List<Study> getStudy()
        {
            using (vitaeEntities Db = new vitaeEntities())
            {
                return Db.Study.Where(
                    st => st.Employee.ID_EMployee == employee.ID_EMployee).ToList();
            }
        }
        ...
    }
