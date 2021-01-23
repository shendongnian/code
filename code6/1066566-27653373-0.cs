        static void Main(string[] args)
        {
            List<ClsState> states = new List<ClsState>
            {
                new ClsState("Gujarat"),
                new ClsState("Maharashtra"),
                new ClsState("Punjab"),
                new ClsState("AndhraPradesh"),
                new ClsState("Telengana"),
            };
            var vowls = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
            var sorted = states
                .Select(s => new Tuple<int, ClsState>(s.StateName.ToCharArray().Where(l => vowls.Contains(l)).Count(), s))
                .OrderByDescending(i => i.Item1)
                .ThenByDescending(i => i.Item2.StateName.Length)
                .ThenBy(i => i.Item2.StateName[0])
                .ThenByDescending(i => states.Where(s => s.StateName == i.Item2.StateName).Count());
        }
