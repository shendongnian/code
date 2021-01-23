    public abstract class User {
        public String Id { get; protected set; }
        public String FirstName { get; protected set; }
        public String LastName { get; protected set; }
        // ...
        public Double SalaryAmount { get; protected set; }
        // ...
        public Int32 VacationBalance { get; protected set; }
        public void TakeVacation(int hours) {
            VacationBalance -= hours;
            }
        }
    public interface IEditable {
        Double SalaryAmount { get; set; }
        }
    public class Employee: User, IEditable {
        #region IEditable Members
        double IEditable.SalaryAmount {
            get { return base.SalaryAmount; }
            set { base.SalaryAmount = value; }
            }
        #endregion
        }
    class Program {
        static void Main(string[] args) {
            var emp = new Employee();
            emp.SalaryAmount = 3; // ERROR!
            ((IEditable) emp).SalaryAmount = 3; // GOOD!
            }
        }
