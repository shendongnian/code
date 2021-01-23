    class Games : IComparable<Games> {
        public int CompareTo(Games other) {
            return GameId.CompareTo(other.GameId);
        }
    }
