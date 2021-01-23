    public class MajorityGateKeeper : IGateKeeper
    {
        public virtual bool CanEnter(string id, int age)
        {
            return age >= 18;
        }
        ... other deep implementation ...
    }
