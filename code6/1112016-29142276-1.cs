    public class GateKeeper : IGateKeeper
    {
        public bool CanEnter(string id)
        {
            return CheckId(id);
        }
        private bool CheckId(string id)
        {
            return id == "Chuck Norris";
        }
        ... other deep implementation ...
    }
