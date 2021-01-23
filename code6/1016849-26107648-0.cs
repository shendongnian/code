    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    namespace SampleApplication
    {
        public class HomeController : Controller
        {
            public ActionResult LargeCsv()
            {
                // TODO: Replace the func with real data access, or alternatively use an IQueryable/IEnumerable/IEnumerator implementation 
                // to access the data dynamically.
                int i = 0;
                Func<string> func = () =>
                {
                    while (i < 100)
                    {
                        i++;
                        return "Name" + i + ", " + i;
                    }
                    return null;
                };
                return new CsvActionResult(func);
            }
        }
        public class CsvActionResult : ActionResult
        {
            private readonly Func<string> _getNextCsvLine;
            public CsvActionResult(Func<string> getNextCsvLine)
            {
                _getNextCsvLine = getNextCsvLine;
            }
            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.Headers.Add("Content-Type", "text/csv");
                context.HttpContext.Response.BufferOutput = false;
                // StreamWriter has inherent buffering so this operation is reasonably performant, it 
                // is going to write buffers to the wire rather than each writeline.
                using (StreamWriter sw = new StreamWriter(context.HttpContext.Response.OutputStream))
                {
                    string csvLine;
                    do
                    {
                        csvLine = _getNextCsvLine();
                        sw.WriteLine(csvLine);
                    } while (csvLine != null);
                }
            }
        }
    }
