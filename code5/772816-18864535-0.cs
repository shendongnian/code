        public class FancyComparer : IEqualityComparer<AnswerDetail>
        {
            public bool Equals(AnswerDetail x, AnswerDetail y)
            {
                return x.Correct == y.Response;
            }
            public int GetHashCode(AnswerDetail obj)
            {
                return 0;
            }
        }
