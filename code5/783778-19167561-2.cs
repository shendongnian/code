    public class Employee
    {
    
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
    
        TimeSpan? _difference = null;
        public TimeSpan Difference
        {
            get
            {
                TimeSpan returnValue;
                if (this._difference.HasValue)
                {
                    returnValue = this._difference.Value;
                }
                else
                {
                       /* COSTLY CALCULATION HERE , ONE TIME */
                    this._difference = this.HireDate.Subtract(this.BirthDate);
                       /* End COSTLY Calculation */
                    returnValue = this._difference.Value;
                }
                return returnValue;
            }
        }
    
    }
