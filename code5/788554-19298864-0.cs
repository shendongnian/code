    public partial class temporaryduty : System.Web.UI.Page
    {
      private int divisionId;
      private int designationId;
...
    if (objDs.Tables[0].Rows.Count > 0)
    {
      lbldiv.Text = objDs.Tables[0].Rows[0]["DIVISION"].ToString();
      lbldesig.Text = objDs.Tables[0].Rows[0]["Designation"].ToString();
      divisionId = objDs.Tables[0].Rows[0]["Expr1"];
      designationId = objDs.Tables[0].Rows[0]["Expr2"];
    }
