     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using System.Data.OleDb;
    using System.Data;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void btnUpload_Click(object sender, EventArgs e)
            {
                if (FileUpload1.HasFile)
                {
                    string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileExtention == ".xls" || fileExtention == ".xlsx")
                    {
                        string fileName = System.IO.Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/ExcelSheet/" + fileName));
                       /*Read excel sheet*/
                        string excelSheetFilename = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/ExcelSheet/" + fileName) + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        OleDbConnection objcon = new OleDbConnection(excelSheetFilename);
                        string queryForExcel = "Select * from [UserDetail$];";
                        OleDbDataAdapter objda = new OleDbDataAdapter(queryForExcel, objcon);
                        DataSet objds = new DataSet();
                        objda.Fill(objds);
                        if (objds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = objds.Tables[0];
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please upload excel sheet.";
                    }
                }
            }
        }
    }
