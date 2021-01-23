    public class VipGateKeeper : MajorityGateKeeper
    {
        public override bool CanEnter(string id, int age)
        {
            // Do the majotity test and check if the id is VIP.
            return base.CanEnter(id, age) && (id == "Chuck Norris");
        }
    }
