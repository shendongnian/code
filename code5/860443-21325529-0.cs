    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data.SqlClient;
    using System.ComponentModel;
    /// <summary>
    /// Summary description for Repeater_Templates
    /// </summary>
    public class Repeater_Templates : ITemplate
    {
       static int itemcount = 0;
       ListItemType templateType;
    public Repeater_Templates(ListItemType type)
    {
       templateType = type;
    }
    public void InstantiateIn(System.Web.UI.Control container)
    {
       Literal lc = new Literal();
       switch( templateType )
       {
          case ListItemType.Header:
              lc.Text = "<table class=\"table zebra-striped\"><thead><tr><th>Equipo</th><th>J</th><th>G</th><th>E</th><th>P</th><th>G</th><th>E</th><th>D</th><th>PTS</th></tr></thead><tbody><tr>";
            break;
         case ListItemType.Item:
            lc.Text = "<td>";
            lc.DataBinding += new EventHandler(TemplateControl_DataBinding);
            break;
         case ListItemType.AlternatingItem:
            lc.Text = "<td>";
            lc.DataBinding += new EventHandler(TemplateControl_DataBinding);
            break;
         case ListItemType.Footer:
            lc.Text = "</tbody></table>";
            break;
      }
      container.Controls.Add(lc);
      itemcount += 1;
    }
    private void TemplateControl_DataBinding(object sender, System.EventArgs e)
    {
        Literal lc;
        lc = (Literal)sender;
        RepeaterItem container = (RepeaterItem)lc.NamingContainer;
        lc.Text += "<img style=\"vertical-align:middle\" src=\"" + DataBinder.Eval(container.DataItem, "LOCATION") + "\" /> "
           + DataBinder.Eval(container.DataItem, "TEAM") + "</td><td>" + DataBinder.Eval(container.DataItem, "GAMES") + "</td><td>" + DataBinder.Eval(container.DataItem, "WON")
            + "</td><td>" + DataBinder.Eval(container.DataItem, "DRAW") + "</td><td>" + DataBinder.Eval(container.DataItem, "LOST") + "</td><td>" + DataBinder.Eval(container.DataItem, "GOALS")
             + "</td><td>" + DataBinder.Eval(container.DataItem, "AGAINST") + "</td><td>" + DataBinder.Eval(container.DataItem, "DIFFERENCE") + "</td><td>" + DataBinder.Eval(container.DataItem, "POINTS");
       lc.Text += "</td><tr>";
    }
    }
