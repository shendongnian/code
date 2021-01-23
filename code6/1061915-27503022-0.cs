    public abstract  class PaymentMethod { 
        public decimal GetSalary(Employee employee, Vehicle vehicle) {
            return GetSalaryImpl(employee, vehicle);
        }    
        protected abstract decimal GetSalaryImpl(Employee employee, Vehicle vehicle);
    }
    public class MarinePaymentMethod : PaymentMethod {
        public decimal GetSalary(Sailor sailor,Boat boat)
        { throw new NotImplementedException(); /* your code here */ }
        protected override decimal GetSalaryImpl(Employee employee, Vehicle vehicle) {
            return GetSalary((Sailor)employee, (Boat)vehicle);
        }
    }    
    public class AirPaymentMethod : PaymentMethod {
        public decimal GetSalary(Pilot pilot, Plane plane)
        { throw new NotImplementedException(); /* your code here */ }
        protected override decimal GetSalaryImpl(Employee employee, Vehicle vehicle) {
            return GetSalary((Pilot)employee, (Plane)vehicle);
        }
    }
    public class Employee {}
    public class Vehicle{}
    public class Sailor : Employee{}
    public class Pilot : Employee{}
    public class Boat: Vehicle{}
    public class Plane: Vehicle{}
