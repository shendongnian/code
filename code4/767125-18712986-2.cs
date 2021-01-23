    static internal class ReqEvalStatus
    {
        public static string GetReqEvalStatus(int agg)
        {
            switch (agg)
            {
                case 1: return "a";
                case 2: return "b";
                case 3: return "c";
                case 4: return "d";
                default: return "";
            }
        }
    }
