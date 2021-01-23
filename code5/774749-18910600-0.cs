    public partial class Form2 : Form
    {
            public Form2()
            {
                InitializeComponent();
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                RST_DBDataContext db = new RST_DBDataContext();
        var d = (from s in db.TblSpareParts
                 select new { s.SPartName, s.SPartCode, s.ModelID, s.SPartLocation, s.SPartActive, newPartSalePrice = s.SPartSalePrice == null ? 0 : s.SPartSalePrice }).ToArray();
        CrystalReport1 c = new CrystalReport1();
        c.SetDataSource(d);
        crystalReportViewer1.ReportSource = c;
    
            } 
    }
