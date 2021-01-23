    public class User
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;
            else
            {
                Usero = obj as User;
                return o.Property1 == this.Property1 && o.Property2 == this.Property2;
            }
        }
    }
