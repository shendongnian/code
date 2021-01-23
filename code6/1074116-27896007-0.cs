	public interface IReader<TParameter, TOutput>
	{
		 TOutput Read(TParameter parameter);
	}
	
	public class Customer : IReader<int, CustomerModel>
	{
		 public CustomerModel Read(int parameter)
		 {      
			 return new CustomerModel() { Id = parameter };
		 }
	}
	
	public class CustomerModel
	{
		public int Id { get; set; }
	}
	
	public class ReaderProxy<TParameter, TOutput>
		: IReader<TParameter, TOutput>
	{
		private IReader<TParameter, TOutput> reader;
		public ReaderProxy(IReader<TParameter, TOutput> reader)
		{
			  this.reader = reader;
		}
		public TOutput Read(TParameter parameter)
		{
			return this.reader.Read(parameter);
		}
	}
	
