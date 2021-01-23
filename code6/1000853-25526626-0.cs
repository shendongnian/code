    public class AssistanceComparer: IEqualityComparer<Assistance>
    {
        public bool Equals(Assistance x, Assistance y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(Assistance assistance)
        {
            return assistance.ID.GetHashCode();
        }
    }
