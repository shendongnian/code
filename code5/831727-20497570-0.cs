    public abstract class PlcValueAbstract
    {
        internal PlcValueAbstract()
        {
        }
    
        public abstract Type GetUnderlyingType();
        public abstract SetValue(byte[] bytes);
    }
	
	public class PlcValueInt : PlcValue<int>
	{
		public override SetValue(byte[] bytes)
		{
			Value = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(bytes, 0));
		}
	}
