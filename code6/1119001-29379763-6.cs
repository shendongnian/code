    public class MsSqlStoreRepository : IStoreRepository
		{
		private string ConnectionString { get; set; }
		public MsSqlStoreRepository(string connectionString)
			{
			ConnectionString = connectionString;
			}
		private bool ProductsTableExists()
			{
			var command = new SqlCommand("select table_name from information_schema.tables where table_type='BASE TABLE' and table_name=@name");
			command.Parameters.AddWithValue("name", "products");
			var dt = MsSqlDatabaseHelpers.GetDataTable(command, ConnectionString);
			if (dt.Rows.Count > 0) return true; else return false;
			}
		private Product GenerateProductFromDataRow(DataRow row)
			{
			return new Product()
			{
				Id = row.Field<int>("id"),
				Name = row.Field<string>("name"),
				Description = row.Field<string>("description"),
				Price = row.Field<double>("price")
			};
			}
		public Product GetProductById(int id)
			{
			var command = new SqlCommand("select id, name, description, price from products where id=@id");
			command.Parameters.AddWithValue("id", id);
			var dt = MsSqlDatabaseHelpers.GetDataTable(command, ConnectionString);
			return dt.AsEnumerable().Select(r => GenerateProductFromDataRow(r)).Single();
			}
		public List<Product> GetAllProducts()
			{
			var command = new SqlCommand("select id, name, description, price from products");
			var dt = MsSqlDatabaseHelpers.GetDataTable(command, ConnectionString);
			return dt.AsEnumerable().Select(r => GenerateProductFromDataRow(r)).ToList();
			}
		public void AddNewProduct(Product product)
			{
			var command = new SqlCommand("insert into products (id, name, description, price) values (@id, @name, @description, @price)");
			command.Parameters.AddWithValue("id", product.Id);
			command.Parameters.AddWithValue("name", product.Name);
			command.Parameters.AddWithValue("description", product.Description);
			command.Parameters.AddWithValue("price", product.Price);
			MsSqlDatabaseHelpers.ExecuteNonQuery(command, ConnectionString);
			}
		public void UpdateProduct(Product product)
			{
			var command = new SqlCommand("update products set name=@name, description=@description, price=@price where id=@id");
			command.Parameters.AddWithValue("id", product.Id);
			command.Parameters.AddWithValue("name", product.Name);
			command.Parameters.AddWithValue("description", product.Description);
			command.Parameters.AddWithValue("price", product.Price);
			MsSqlDatabaseHelpers.ExecuteNonQuery(command, ConnectionString);
			}
		public void DeleteProduct(int id)
			{
			var command = new SqlCommand("delete from products where id=:id");
			command.Parameters.AddWithValue("id", id);
			MsSqlDatabaseHelpers.ExecuteNonQuery(command, ConnectionString);
			}
		}
