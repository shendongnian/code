    public class School{
        private IPerson _director;
        public School(IStaffRepository staffing){
           _director = staffing.GetDirector(_schoolName);
        }
    }
