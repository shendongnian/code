    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    namespace ROT.TestConsole
    {
        /// <summary>
        /// Gets MS Excel running workbook instances via ROT
        /// </summary>
        public class MSExcelWorkbookRunningInstances
        {
            [DllImport("ole32.dll")]
            static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);
            [DllImport("ole32.dll")]
            public static extern void GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
            public static IEnumerable<dynamic> Enum()
            {
                // get Running Object Table ...
                IRunningObjectTable Rot;
                GetRunningObjectTable(0, out Rot);
                // get enumerator for ROT entries
                IEnumMoniker monikerEnumerator = null;
                Rot.EnumRunning(out monikerEnumerator);
                IntPtr pNumFetched = new IntPtr();
                IMoniker[] monikers = new IMoniker[1];
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                while (monikerEnumerator.Next(1, monikers, pNumFetched) == 0)
                {
                    string applicationName = "";
                    dynamic workBook = null;
                    try
                    {
                        Guid IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");                    
                        monikers[0].BindToObject(bindCtx, null, ref IUnknown, out workBook);
                        applicationName = workBook.Application.Name;
                    }
                    catch { }
                    if (applicationName == "Microsoft Excel") yield return workBook;
                }
            }
        }
    }
