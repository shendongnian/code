    public class Applicant : Person
    {
        //Only extra properties and methods here.
        
        public string FullName 
        {
            get 
            {
                return this.BorrowerFirst + " " + this.BorrowerMI + " " + this.BorrowerLast;
            }
        }
    }
