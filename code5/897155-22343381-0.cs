    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Drawing;
    
    namespace webapp1
    {
        public partial class _Default : System.Web.UI.Page
        {
        DataTable dtDetails = new DataTable();
        protected void Grd_QADetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dataRowView = e.Row.DataItem as DataRowView;
                DataRow row = dataRowView.Row;
                var Current = (row["Dosage"] as int?) ?? null;
                if (Current != null)
                {
                    if (Current >= 1 && Current < 10)
                        e.Row.Cells[1].BackColor = Color.Green;
                    else if (Current >= 10 && Current < 20)
                        e.Row.Cells[1].BackColor = Color.Yellow;
                    else
                        e.Row.Cells[1].BackColor = Color.Red;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            dtDetails.Columns.Add("Dosage", typeof(int));
            dtDetails.Columns.Add("Drug Suggested", typeof(string));
            dtDetails.Columns.Add("Patient Name", typeof(string));
            dtDetails.Columns.Add("Date", typeof(DateTime));
            dtDetails.Columns.Add("Type", typeof(string));
            dtDetails.Columns.Add("Payment Mode", typeof(string));
            dtDetails.Columns.Add("Appointment Status", typeof(string));
            dtDetails.Columns.Add("Location", typeof(string));
            dtDetails.Rows.Add(1, "Indocin", "David", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(2, "Enebrel", "Sam", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(3, "Hydralazine", "Christoff", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(4, "Combivent", "Janet", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(5, "Dilantin", "Melanie", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(6, "Indocin", "David", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(7, "Enebrel", "Sam", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(8, "Hydralazine", "Christoff", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(9, "Combivent", "Janet", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(10, "Dilantin", "Melanie", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(11, "Indocin", "David", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(12, "Enebrel", "Sam", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(13, "Hydralazine", "Christoff", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(14, "Combivent", "Janet", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
            dtDetails.Rows.Add(15, "Dilantin", "Melanie", DateTime.Now, "Casuality", "Cash", "Pending", "Kolkatta");
      
            if (!IsPostBack)
            {
                grdDetails.DataSource = dtDetails;
                grdDetails.DataBind();
            }
        }
        protected void ExportToGrid(object sender, EventArgs e)
        {
            ExportToGrid(dtDetails);
        }
        private void ExportToGrid(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string filename = "Test" + ".xls";
                using (System.IO.StringWriter tw = new System.IO.StringWriter())
                {
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    GridView dgGrid = new GridView();
                    dgGrid.DataSource = dt;
                    dgGrid.RowDataBound += new GridViewRowEventHandler(Grd_QADetails_RowDataBound);
                    dgGrid.DataBind();
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">" + Environment.NewLine);
                    Response.Write(tw.ToString());
                    Response.Write("</body>");
                    Response.Write("</html>");
                    Response.End();
                }
            }
        }
    }
}
    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
        CodeBehind="Default.aspx.cs" Inherits="webapp1._Default" %>
    
    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:GridView runat="server" ID="grdDetails" OnRowDataBound="Grd_QADetails_RowDataBound">
    
        </asp:GridView>
        <asp:Button  runat="server" ID="btnSubmit" OnClick="ExportToGrid"/>
    </asp:Content>
