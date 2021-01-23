    using System;
    using System.Windows.Forms;
    using System.Diagnostics;
    using PdfSharp;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = null;
                SqlConnection connection ;
                SqlCommand command ;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                int i = 0;
                string sql = null;
                int yPoint = 0;
                string pubname = null;
                string city = null;
                string state = null;
                connetionString = "Data Source=YourServerName;Initial Catalog=pubs;User ID=sa;Password=zen412";
                sql = "select pub_name,city,country from publishers";
                connection = new SqlConnection(connetionString);
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                connection.Close();
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Database to PDF";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 20, XFontStyle.Regular );
                yPoint = yPoint + 100;
                for (i = 0; i < = ds.Tables[0].Rows.Count - 1; i++)
                {
                    pubname = ds.Tables[0].Rows[i].ItemArray[0].ToString ();
                    city = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                        
                    graph.DrawString(pubname, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(city, font, XBrushes.Black, new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(state, font, XBrushes.Black, new XRect(420, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    yPoint = yPoint + 40;
                }
                string pdfFilename = "dbtopdf.pdf";
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
