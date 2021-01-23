    static internal class ReqType
    {
        public static string GetReqType(int type)
        {
            switch (type)
            {
                case 1: return "a";
                case 2: return "b";
                case 3: return "c";
                case 4: return "d";
                default: return "";
            }
        }
    }
