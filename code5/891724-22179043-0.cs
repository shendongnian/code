    class Chameleon
    {
        private double length;
        private string name;
        private string color;
        public Chameleon(string nameValue, double lengthValue, string colorValue)
        {
            name = nameValue;
            length = lengthValue;
            color = colorValue;
        }
        public Chameleon(string nameValue, double lengthValue)
        {
            name = nameValue;
            length = lengthValue;
        }
        public Chameleon(string nameValue, string colorValue)
        {
            name = nameValue;
            color = colorValue;
        }
    }
