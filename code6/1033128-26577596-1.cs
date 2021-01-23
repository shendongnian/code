    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    public partial class Link_l : System.Web.UI.Page
    {
    string weburl;
    protected void Page_Load(object sender, EventArgs e)
    {
        AddMetaContentType();
        //add noscript to literal for users to have javascript disabled.
        nsliteral.Text = "<noscript><meta http-equiv=REFRESH content=0;URL=" + Request.Url + "&js=0></noscript>";
            //read querystring and pull link info from database, then redirect to link destination
            //redirect user to proper destination link that was clicked on in https page
            //created to get around https (secure) site preventing referrer url showing in stats when linking out to http sites for browsers that won't recognize the "content-type" meta tag.
            if (Request.QueryString["id"].ToString() != null)
            {
                SqlDataSource ds = new SqlDataSource();
                ds.ID = "LinkDataSource";
                Page.Controls.Add(ds);
                ds.ConnectionString = WebConfigurationManager.ConnectionStrings["yourConnectionStringNameHere"].ConnectionString;
                ds.SelectCommand = "SELECT ID, LinkURL FROM your_DatabaseTable WHERE ID = @ID";
                if (!IsPostBack)
                {
                    ds.SelectParameters.Add("ID", DbType.Int32, Request.QueryString["ID"].ToString());
                }
                DataView dv;
                dv = (DataView)ds.Select(DataSourceSelectArguments.Empty);
                if (dv.Table.Rows.Count > 0)
                {
                    DataRowView dr = dv[0];
                    weburl = (string)dr["LinkURL"].ToString();
                    if (Request.QueryString["js"] != null)
                    {
                        //JavaScript is not detected to be enabled
                        Response.Redirect("http://" + weburl, false);
                    }
                    else
                    {
                        //JavaScript is detected okay. Add javascript to click button with id "testbtn"
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ClickScript", "<script language='javascript'>document.getElementById('" + testbtn.ClientID + "').click();</script>");
                    }
                }
            }
            else
            {
                 //this page was visited with no id value in querystring
            }
    }
    protected void Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://" + weburl, false);
    }
    private void AddMetaContentType()
    {
        //went ahead and added meta tag that will help define referring domain in some browsers
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "content-type";
        meta.Content = Response.ContentType + "; charset=" + Response.ContentEncoding.HeaderName;
        Page.Header.Controls.Add(meta);
    }
    }
