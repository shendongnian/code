    public class EntitiesStatus
    {
        public EntitiesStatus(bool isAOK, bool isBOK)
        {
            IsEntity1OK = isAOK;
            IsEntity2OK = isBOK;
        }
        IsEntity1OK { get; private set; }
        IsEntity2OK { get; private set; }
    }
