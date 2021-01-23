    public enum EnumColor
    {
        Blue = 0,
        Red = 1,
    }
    public class Car : IColoredObject<EnumColor>
    {
        private EnumColor m_Color;
        public EnumColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        public Car()
        {
        }
    }
    class Program
    {
        static void Main()
        {
            Car car = new Car();
            IndependentClass.DoesItWork<EnumColor>( car );
        }
    }
