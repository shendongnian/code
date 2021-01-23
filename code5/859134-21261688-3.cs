    abstract class Role 
    { 
        public abstract string GetDestination();
    }
    class Manager : Role
    {
        public virtual string GetDestination() { return "ManagerHomeA"; }
    }
    string GetDestination(Role role)
    {
        return @"\" + role.GetDestination();
    }
