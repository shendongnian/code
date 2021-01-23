	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			UpdateDataGridView();
		}
		private void UpdateDataGridView()
		{
			byte[] bmp = new byte[28];
			List<BMPInfo> InfoList = new List<BMPInfo>();
			using (var fs = new FileStream("D:\\x.bmp", FileMode.Open, FileAccess.Read))
			{
				fs.Read(bmp, 0, bmp.Length);
			}
			InfoList.Add(new BMPInfo
			{
				Offset = BitConverter.ToInt32(bmp, 10),
				Size = BitConverter.ToInt32(bmp, 2),
				Description = "Something"
			});
			dataGridView1.DataSource = InfoList;
		}
	}
	public class BMPInfo
	{
		public long Offset { get; set; }
		public long Size { get; set; }
		public string Description { get; set;}
	}
