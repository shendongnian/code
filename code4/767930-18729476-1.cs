    public Employee(int annualSalary)
    {
        salary = annualSalary;
    }
    public Employee(int weeklySalary, int numberOfWeeks)
        : this(weeklySalary * numberOfWeeks)
    {
    }
