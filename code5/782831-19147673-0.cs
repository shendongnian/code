	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Model : Form
		{
			public Model()
			{
				InitializeComponent();
				var bll = new BLL(new DAL());
				bll.WriteToDatabase("mydbvalue");
			}
		}
		public interface IBll
		{
			void WriteToDatabase(string value);
		}
		public class BLL: IBll
		{
			private IDal _dataLayer;
			public BLL(IDal dataLayer)
			{
				_dataLayer = dataLayer;
			}
			public void WriteToDatabase(string value)
			{
				_dataLayer.WriteToDatabase(value);
			}
		}
		public interface IDal
		{
			void WriteToDatabase(string value);
		}
		public class DAL:IDal
		{
			public void WriteToDatabase(string value)
			{
				var sql = "update t set t.field = '" + value + "' from table t";
			}
		}
	}
