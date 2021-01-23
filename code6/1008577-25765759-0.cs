    private struct MemberAccessKey
    {
        public readonly Type Type;
        public readonly MemberInfo Member;
        public MemberAccessKey(Type t, MemberInfo m)
        {
            Type = t; Member = m;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is MemberAccessKey)) return false;
            var other = (MemberAccessKey)obj;
            return other.Type == Type && other.Member == Member;
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Member.GetHashCode();
        }
    }
