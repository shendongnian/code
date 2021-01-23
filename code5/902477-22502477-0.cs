    using System.Runtime.InteropServices;
     
    namespace Microsoft.Office.Interop.Excel
    {
        [CoClass(typeof(WorkbookClass))]
        [Guid("000208DA-0000-0000-C000-000000000046")]
        public interface Workbook : _Workbook, WorkbookEvents_Event
        {
        }
    }
