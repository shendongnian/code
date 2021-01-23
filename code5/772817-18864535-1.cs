        public class FancyComparer : IEqualityComparer<AnswerDetail>
        {
            public bool Equals(AnswerDetail x, AnswerDetail y)
            {
                return x.AnswerId == y.AnswerId && x.Correct == y.Response;
            }
            public int GetHashCode(AnswerDetail obj)
            {
                return obj.AnswerId;
            }
        }
