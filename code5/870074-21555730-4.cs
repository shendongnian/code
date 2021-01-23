    public partial class detail : Window
    {
        private int empId;
        public detail(int empId)
        {
            this.empId = empId;
            ...
        }
        private List<Study> getStudy()
        {
            using (vitaeEntities Db = new vitaeEntities())
            {
                return Db.Study.Where(
                    st => st.Employee.ID_EMployee == empId).ToList();
            }
        }
        ...
    }
