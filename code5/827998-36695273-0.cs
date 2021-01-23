    **//This controller.cs class will make a .pdf file from the query output.  Change //the values at "p" from the attributes of your database table.
    //The href tag of calling the controller class Action Export method from the //View class as a MVC design is: 
    // <a href="@Url.Action("Export","tblOrder")">Print Orders</a>
    //Make sure to make the model class with crystal report design and ADO.NET //dataset.  I have only include the controller class of the MVC model to 
    //make it work only.**
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MvcApplicationCrystalReportRptSTP.Reports;
    using MvcApplicationCrystalReportRptSTP.Models;
    using CrystalDecisions.CrystalReports.Engine;
    using System.IO;
    
    namespace MvcApplicationCrystalReportRptSTP.Controllers
    {
        public class tblOrderController : Controller
        {
            private DB_JDBCLOGEntities mde = new DB_JDBCLOGEntities();
            //
            // GET: /tblOrder/
    
            public ActionResult Index()
            {
                ViewBag.ListProducts = mde.tblOrders.ToList();
                return View();
            }
            public ActionResult Export()
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/CrystalReporttblOrder.rpt")));
                rd.SetDataSource(mde.tblOrders.Select(p=> new
                {
                ID=  p.ID,
                Ordernum=p.Ordernum,
                Username=p.Username,
                Password=p.Password,
                Price=p.Price.Value,
                AddCart=p.AddCart.Value,
                Image=p.Image
                }).ToList());
                Response.Buffer=false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream,"application/pdf","tblOrder.pdf");
            }
        }
    }
