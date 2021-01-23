    public class Plane : IFly<int>, IFly<object>
    {
        public int GetMark()
        {
            return 123;
        }
        object IFly<object>.GetMark()
        {
            return GetMark();
        }
    }
