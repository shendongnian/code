    using System.Web.UI.HtmlControls;
...
     HtmlTableCell cell = new HtmlTableCell();
     cell.InnerText= "test";  //  change cell.Text to cell.InnerText
     cell.Attributes.Add("class", "d");
     agentsNames.Cells.Add(cell);
