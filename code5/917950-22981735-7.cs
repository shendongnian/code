    public class ShiftByNameWithOccurences : AbstractQueryObject<IList<Shift>>
    {
        private string Name;
        public ShiftByNameWithOccurences(string name)
        {
            this.Name = name;
        }
        public override IList<Shift> GetResult()
        {
            var list =
            (
                from shift in this.Session.Query<Shift>()
                where shift.Name == this.Name
                select shift
                
            )
            .Fetch(p => p.Occurrences)
            .ToList();
            return list;
        }
    }
