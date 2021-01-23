    [webmethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public static List<Problem> GetProblems()
        {
            List<Problem> allproblems = new List<Problem>();
            using (TMEntities tm = new TMEntities())
            {
                allproblems = tm.Problems.ToList();    
            }
           return allproblems;
        }
