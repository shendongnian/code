	public class Product
	{
	}
	public class DataAccessClass : IDataAccessClass
	{
		public void Insert(Product product)
		{
		}
	}
	public interface IDataAccessClass
	{
		void Insert(Product product);
	}
	public class ProductLogic
	{
		IDataAccessClass _dataAccessClass;
		//DataAccessClass should be injected here using Ninject
		public ProductLogic(IDataAccessClass dataAccessClass)
		{
			_dataAccessClass = dataAccessClass;
		}
		public void InsertProduct(Product product)
		{
			_dataAccessClass.Insert(product);
		}
	}
