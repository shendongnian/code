    public class DrunkGateKeeper : VipGateKeeper 
    {
        public override bool CanEnter(string id, int age)
        {
            return true;
        }
    }
