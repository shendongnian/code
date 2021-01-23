    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicData_JIM._Default" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script type="text/javascript" language="javascript">
            function removeImage(id) {
                PageMethods.RemoveImage(id, onSucess, onError);
            }
            function onSucess(result) {
                alert(result);
                document.getElementById("btnClick").click();
            }
            function onError(result) {
                alert('Something wrong.');
            }
        </script>
        
    </head>
    <body>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div>
            <asp:Button ID="btnClick" Text="Click" runat="server" OnClick="btnClick_Click" />
            <asp:Panel ID="pnldynamic" runat="server">
            </asp:Panel>
        </div>
        </form>
    </body>
    </html>
 
 
     
        
        protected void btnClick_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBM.SqlCommandEx sqlCmd = new DBM.SqlCommandEx(String.Format("SELECT  [id],[image] FROM images WHERE slider = 1", "", "")))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt = sqlCmd.GetDataTable();
                    Int32 icount = 0;
                    pnldynamic.Controls.Clear();
                    pnldynamic.Controls.Add(new LiteralControl("<table>"));
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        String LabelId = "lbl" + icount.ToString();
                        String buttonid = dr["id"].ToString();
                        pnldynamic.Controls.Add(new LiteralControl("<tr><td>"));
                        pnldynamic.Controls.Add(new LiteralControl("<span>" + dr["image"].ToString() + "</span>"));
                        pnldynamic.Controls.Add(new LiteralControl("</td><td>"));
                        pnldynamic.Controls.Add(new LiteralControl("<input type='button' id=" + buttonid + " value='Remove' onclick='removeImage(" + dr["id"].ToString() + ");' />"));
                        pnldynamic.Controls.Add(new LiteralControl("</td></tr>"));
                        icount++;
                    }
                    pnldynamic.Controls.Add(new LiteralControl("</table>"));
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
            }
        }
        
        [WebMethod]
        public static string RemoveImage(string id)
        {
            String msg = "Success";
            Int32 iresult = 0;
            try
            {
                iresult = DBM.ExecuteNonQuery("UPDATE   images SET  slider = 0 WHERE id = " + id + "");
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
            }
            return msg;
        }
    }
 
 
