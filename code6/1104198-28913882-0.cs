        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.IO;
        using InventoryTracker.DAL;
        using OfficeOpenXml;
        using InventoryTracker.Models;
        using System.Reflection;
        using OfficeOpenXml.Table;
        namespace InventoryTracker.Controllers
        {
            public class ExportController : Controller
            {
                private InventoryTrackerContext _db = new InventoryTrackerContext();
                [HttpPost]
                public ActionResult ExportUsingEPPlus(ExportAssetsViewModel model)
                {
                    //FileInfo newExcelFile = new FileInfo(output);
                    ExcelPackage package = new ExcelPackage();
                    var ws = package.Workbook.Worksheets.Add("TestExport");
                    var exportFields = new List<string>();
                    foreach (var selectedField in model.SelectedFields)
                    {
                        // Adds selected fields to [exportFields] List<string>
                        exportFields.Add(model.ListOfExportFields.First(s => s.Key == selectedField).Value);
                    }
                    // Loops to insert column headings into Row 1 of Excel
                    for (int i = 0; i < exportFields.Count(); i++)
                    {
                        ws.Cells[1, i + 1].Value = exportFields[i].ToString();
                    }
                    var membersToShow = typeof(INV_Asset).GetMembers()
                        .Where(p => exportFields.Contains(p.Name))
                        .ToArray();
                    ws.Cells["A2"].LoadFromCollection(_db.INV_Assets.ToList(), false, TableStyles.None, BindingFlags.Default, membersToShow);
                    var memoryStream = new MemoryStream();
                    package.SaveAs(memoryStream);
                    string fileName = "Exported-InventoryAssets-" + DateTime.Now + ".xlsx";
                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    memoryStream.Position = 0;
                    return File(memoryStream, contentType, fileName);
                }
            }
        }
