    public class FinalClassScoreModel
    {
        private readonly FinalClassScore _finalClassScore;
        private readonly Enroll _enroll;
        public FinalClassScoreModel(FinalClassScore finalClassScore, Enroll enroll)
        {
            this._finalClassScore = finalClassScore;
            this._enroll = enroll;
        }
        public int EnrollId
        {
            get
            {
                return this._finalClassScore.EnrollId;
            }
        }
        public string StudentNo
        {
            get
            {
                return this._enroll.StudentNo;
            }
        }
  
