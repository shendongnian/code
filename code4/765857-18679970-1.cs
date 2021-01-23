    [assembly: CLSCompliant(true)]
    namespace SampleNSpace
    {
    	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
    	[Guid("111B0014-EB08-4093-A818-1D11EB4C489D")]
    	public class AnyClass
    	{
    		public int GetAnyInt() { return int.MaxValue; }
    
    		[return: MarshalAs(UnmanagedType.Struct)]
    		public object GetAnyLong() { return long.MaxValue; }
    
    		[return: MarshalAs(UnmanagedType.Currency)]
    		public decimal GetAnyDecimal() { return decimal.MaxValue; }
    		
    		[return: MarshalAs(UnmanagedType.Struct)]
    		public object GetAnyDouble() { return double.MaxValue; }
    	}
    }
