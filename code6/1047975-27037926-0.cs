    public partial class Student
    {
        DateTime StartDateComputed {
            get
            {
                return  FixDateToCurrentYear(StartDate);
            }
            set;
        }
    }
