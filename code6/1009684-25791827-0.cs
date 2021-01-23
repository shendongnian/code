    public class Team : IEnumerable<HeroStats>
    {
        private HashSet<HeroStats> stats = new HashSet<HeroStats>();
    
        public IEnumerator<HeroStats> GetEnumerator()
        {
            return stats.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return stats.GetEnumerator();
        }
    }
