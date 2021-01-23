    internal interface IStar
    {
        void Method1();
        string Property1 { get; }
        ...
    }
    internal abstract class Star : IStar
    {
        protected Star()
        {
            foreach(string planetName in planetNames)
            {
                Planet p = new Planet(planetName, this);
                Planets.Add(p);
            }
        }
        public void Method1()
        {
            ...
        }
        public string Property1
        {
            get { return string.Empty; }
        }
    }
    internal class Planet
    {
        string name;
        IStar parentStar;
        internal Planet(string name, IStar parentStar)
        {
            this.name = name;
            this.parentStar = parentStar;
        }
    }
