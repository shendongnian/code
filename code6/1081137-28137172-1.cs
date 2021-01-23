      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Web;
      using System.Web.UI;
      using System.Web.UI.WebControls;
      namespace WebApplication1
      {
         public partial class WebForm1 : System.Web.UI.Page
         {
            private int AttributesCount
            {
               get
               {
                  int ret = 0;
                  if (Session["AttributesCount"] != null && int.TryParse(Session["AttributesCount"].ToString(), out ret))
                  {
                     ;
                  }
                  return ret;
               }
               set
               {
                  Session["AttributesCount"] = value;
               }
            }
            protected override void OnInit(EventArgs e)
            {
               base.OnInit(e);
               RenderTextboxes();
            }
            private void RenderTextboxes()
            {
               for (int i = 0; i < AttributesCount; i++)
               {
                  Label labels = new Label();
                  labels.Text = "AttributeName" + (i + 1).ToString();
                  TextBox textBoxes = new TextBox();
                  textBoxes.ID = "TextBoxAttributeName" + (i + 1).ToString();
                  PlaceHolder1.Controls.Add(labels);
                  PlaceHolder1.Controls.Add(new LiteralControl(" "));
                  PlaceHolder1.Controls.Add(textBoxes);
                  PlaceHolder1.Controls.Add(new LiteralControl("<BR>"));
               }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
               int a = Convert.ToInt16(DropDownList1.SelectedValue);
               AttributesCount = a;
               RenderTextboxes();
               DropDownList1.Enabled = false;
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
               for (int i = 0; i < AttributesCount; i++)
               {
                  TextBox tt = (TextBox)PlaceHolder1.FindControl("TextBoxAttributeName" + (i + 1));
                  Response.Write(tt.Text);
                  //Response.Redirect("~/WebForm1.aspx");
               }
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
               ClientScript.RegisterStartupScript(this.GetType(), "AddRelationship", "<script>AddRelationship();</script>");
               //Response.Redirect("~/WebForm2.aspx");
            }
         }
      }
