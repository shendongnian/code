        public class AViewModel : ITestModelB
        {
            private TestViewModelB _model;
            public TestViewModelB model
            {
                get
                {
                    return _model;
                }
                set
                {
                    _model = value;
                }
            }
            private TestViewModel newmodel;
            TestViewModel ITestModel.model
            {
                get { return newmodel; }
                set { newmodel = value; }
            }
            public void PopulateNewReferralRequestModel(Int32 ReferralTypeID, Int32 profileid, string UniqueKeyValues)
            {
                model = new TestViewModelB();
                model.comments = "New model created";
                model.id = 1;
                model.name = "Referral Type 1";
                model.anotherfield = profileid;
                model.anotherstringfield = UniqueKeyValues;
            }
            public void Save()
            {
                int i = 1;
                return;
            }
        } 
