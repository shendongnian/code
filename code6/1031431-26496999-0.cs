    public partial class Customer
    {
        public string AllNames
        {
            get { return FirstName + " "  + MiddleName + " " + LastName + " " + NickName }
        }
    }
