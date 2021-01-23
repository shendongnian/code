    class MagicClass
    {
        string[] Values = new string[Enum.GetValues(typeof(MagicClassValues)).Length];
        public string this[MagicClassValues Value] //and/or a GetValue/SetValue construction
        {
            get
            {
                return Values[(int)Value];
            }
            set
            {
                Values[(int)Value] = value;
                hash = null;
            }
        }
        int? hash; //buffered for optimal dictionary performance and == comparisson
        public override int GetHashCode()
        {
            if (hash == null)
                unchecked
                {
                    hash = Values.Sum(s => s.GetHashCode());
                }
            return hash.Value;
        }
        public static bool operator ==(MagicClass v1, MagicClass v2) //used == operator, in compliance to the question, but this would be better for 'Equals'
        {
            if(ReferenceEquals(v1,v2))return true;
            if(ReferenceEquals(v1,null) || ReferenceEquals(v2,null) || v1.GetHashCode() != v2.GetHashCode())return false;
            return v1.Values.SequenceEqual(v2.Values);
        }
        public static bool operator !=(MagicClass v1, MagicClass v2)
        {
            return !(v1 == v2);
        }
        //optional, use hard named properties as well
        public string FirstAttribute { get { return this[MagicClassValues.FirstAttribute]; } set { this[MagicClassValues.FirstAttribute] = value; } }
    }
    public enum MagicClassValues
    {
        FirstAttribute,
        SecondAttribute,
        //etc
    }
