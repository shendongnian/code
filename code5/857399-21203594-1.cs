    public interface IColoredObject<EnumColorType>
    {
        EnumColorType Color
        {
            get;
        }
    }
    public static class IndependentClass
    {
        public static void DoesItWork<EnumColorType>( object car )
        {
            IColoredObject<EnumColorType> coloredObject = car as IColoredObject<EnumColorType>;
            if( coloredObject == null )
                Console.WriteLine( "It doesn't work." );
            else
            {
                Console.WriteLine( "It works." );
                int colorNumber = (int)( coloredObject.Color as object );
                Console.WriteLine( "Car has got color number " + colorNumber + "." );
            }
        }
    }
