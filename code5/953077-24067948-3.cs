    public class CustomerComparison : IComparer<Customer>
    {
        private IComparer<string> _RoleComparer = new MemberRoleComparison();
        int IComparer<Customer>.Compare(Customer x, Customer y)
        {
            int result = _RoleComparer.Compare(x.memberRole, y.memberRole);
            result = result == 0 ? string.Compare(x.Firstname, y.Firstname) : result;
            return result == 0 ? string.Compare(x.Lastname, y.Lastname) : result;
        }
    }
