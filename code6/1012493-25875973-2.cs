    public interface ITestModel<Tmodel>
    {
        Tmodel model { get; set; }
        void PopulateNewReferralRequestModel(Int32 ReferralTypeID, Int32 profileid, string UniqueKeyValues);
        void Save();
    }
