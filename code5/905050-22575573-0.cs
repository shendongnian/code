    public abstract class SpaceshipManager: MonoBehaviour
    {
        public void BuildWith<T>(T po)
        {
            if (ValidateBuildParam<T>())
            {
                Build<T>(po);
            }
        }
        protected abstract bool ValidateBuildParam<T>();
        protected abstract void Build<T>(T type);
    }
    public class DerivedA : SpaceshipManager
    {
        protected override void Build<T>(T po)
        {
            //Build here
        }
        protected override bool ValidateBuildParam<T>()
        {
            return (typeof(T) != typeof(ParseObject)) ? false : true;
        }
    }
    public class DerivedB : SpaceshipManager
    {
        protected override void Build<T>(T po)
        {
            //Build here   
        }
        protected override bool ValidateBuildParam<T>()
        {
            return (typeof(T) != typeof(string)) ? false : true;
        }
    }
