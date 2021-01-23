    public class Employee(int annualSalary)
    {
        salary = annualSalary;
    }
    public class Employee(int weeklySalary, int numberOfWeeks)
        : this(weeklySalary * numberOfWeeks)
    {
    }
