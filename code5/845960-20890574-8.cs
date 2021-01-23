    enum Priority : byte
    {
        High,
        Medium,
        Low
    }
    static class Priorities
    {
        private static Dictionary<char, Priority> _toPriority = new Dictionary<char, Priority>();
        private static Dictionary<Priority, char> _fromPriority = new Dictionary<Priority, char>();
        static Priorities()
        {
            var priorities = Enum.GetNames(typeof(Priority));
            var values = (Priority[])Enum.GetValues(typeof(Priority));
            for (var i = 0; i < priorities.Length; i++)
            {
                _toPriority.Add(priorities[i][0], values[i]);
                _fromPriority.Add(values[i], priorities[i][0]);
            }
        }
        public static Priority GetPriority(string field)
        {
            Priority res;
            if (!TryGetPriority(field, out res))
                throw new ArgumentException("Invalid priority on field.", "field");
            return res;
        }
        public static bool TryGetPriority(string field, out Priority priority)
        {
            if (field == null || field.Length == 0) { priority = default(Priority); return false; }
            return _toPriority.TryGetValue(field[0], out priority);
        }
        public static char GetCode(Priority priority)
        {
            return _fromPriority[priority];
        }
    }
