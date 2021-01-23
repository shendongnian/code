    public partial class Form1 : Form
    {
    	private Dictionary<string, Type> _columnTypes;
    	
    	public Form1()
    	{
    		InitializeComponent();
    
    		_columnTypes = new Dictionary<string, Type>();
    		_columnTypes.Add("FooFoo2", typeof(IFoo));
    	}
    
    	
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		var columnNames = new List<string> { "Foo", "Foo2" };
    		var customerOrderCsvReader = new List<List<string>> { new List<string> { "Bar", "Bar2" } };
    
    		var type = _columnTypes[string.Join("", columnNames)];
    
    		var type2 = typeof(DataSourceBuilder<>).MakeGenericType(type);
    		dynamic dataBuilder = Activator.CreateInstance(type2);  
    
    		var list = dataBuilder.GetDataSource(columnNames, customerOrderCsvReader);
    		dataGridView1.DataSource = list;
    	}
    }
    
    public class DataSourceBuilder<T> where T : class, IDataSource
    {
    	public List<T> GetDataSource(List<string> columnNames, List<List<string>> customerOrderCsvReader)
    	{
    		var list = new List<T>();
    		foreach (var element in customerOrderCsvReader)
    		{
    			dynamic expando = new ExpandoObject();
    			var temp = (IDictionary<string, object>)expando;
    			int i = 0;
    			foreach (string columnName in columnNames)
    			{
    				temp[columnName] = element[i];
    				i++;
    			}
    			var foo = Impromptu.ActLike<T>(temp);
    			list.Add(foo);
    		}
    
    		return list;
    	}
    }
    
    public interface IDataSource
    {
    }
    
    public interface IFoo : IDataSource
    {
    	string Foo { get; set; }
    	string Foo2 { get; set; }
    }
