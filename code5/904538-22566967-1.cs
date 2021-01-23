    public class Key
    {
        public bool IsRelevant(Key other)
        {
            return (this.GetType().IsSubclassOf(other.GetType()))
                && (this.Name == other.Name);
        }
    }
