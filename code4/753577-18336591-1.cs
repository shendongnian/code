    public class Creature
    {
        private string _name = "Elmo";
        public virtual string Name { get { return _name; } set { _name = value; } }
    }
    public class Cat : Creature
    {
        private string _name = "Ernie";
        public override string Name { get { return _name; } set { _name = value; } }
    }
