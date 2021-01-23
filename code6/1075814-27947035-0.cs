    public interface ICar
    {
        string GetMake();
        string GetModel();
    }
     
    public class ToyotaCamry : ICar
    {
        #region ICar Members
     
        public string GetMake()
        {
            return "Toyota";
        }
        public string GetModel()
        {
            return "Camry";
        }
     
        #endregion
    }
     
    public class FordMustang : ICar
    {
        #region ICar Members
     
        public string GetMake()
        {
            return "Ford";
        }
     
        public string GetModel()
        {
            return "Mustang";
        }
        #endregion
    }
     
    public enum CarType
    {
        FordMustang,
        ToyotaCamry
    }
     
    /// <summary>
    /// Implementation of Factory - Used to create objects
    /// </summary>
    public class Factory
    {
        public ICar GetCar(CarType type)
        {
            switch (type)
            {
                case CarType.FordMustang :
                    return new FordMustang();
                case CarType.ToyotaCamry:
                    return new ToyotaCamry();
            }
            return null;
        }
    }
