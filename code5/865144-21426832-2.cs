    public class RequestForSalaryVM : StatementViewModel
    {
        public override StatementType StatementType
        {
            get { return StatementType.RequestForSalary; }
        }
        ...
    }
    public class ReliefVM : StatementViewModel
    {
        public override StatementType StatementType
        {
            get { return StatementType.Relief; }
        }
        ...
    }
