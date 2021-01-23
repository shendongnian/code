    public interface IConverter
    {
    	object Convert(object incomingObject);
    }
    
    public class Converter<TIncoming, TOutgoing> : IConverter
    {
    	private Func<TIncoming, TOutgoing> ConversionFunction;
    	
    	public Converter(Func<TIncoming, TOutgoing> conversionFunction)
    	{
    		this.ConversionFunction = conversionFunction;
    	}
    
    	public object Convert(object incomingObject)
    	{
    		TIncoming typedIncomingObject = (TIncoming)incomingObject;
    		return ConversionFunction(typedIncomingObject);
    	}
    }
