    public partial class Form1 : Form
    {
        string tempFileName;
        Image img;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DBEngine dbe = new DBEngine();
            Database db = dbe.OpenDatabase(@"C:\Users\Public\AttachmentsDB.accdb");
            Recordset rsMain = db.OpenRecordset(
                    "select solution from tab2 where id = 1",
                    RecordsetTypeEnum.dbOpenSnapshot);
            Recordset2 rsAttach = rsMain.Fields["solution"].Value;
            tempFileName = System.IO.Path.GetTempPath() + "\\" + rsAttach.Fields["FileName"].Value;
            try
            {
                System.IO.File.Delete(tempFileName);
            }
            catch { }
            Field2 fldAttach = (Field2)rsAttach.Fields["FileData"];
            fldAttach.SaveToFile(tempFileName);
            rsAttach.Close();
            rsMain.Close();
            db.Close();
            img = Image.FromFile(tempFileName);
            pictureBox1.Image = img;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            img.Dispose();
            System.IO.File.Delete(tempFileName);
        }
    }
