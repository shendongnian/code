    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using EnvDTE80;
    class DetachDebugger
    {
        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);
        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
        public static void Detach()
        {
            var dte = GetCurrent();
            dte.Debugger.DetachAll();
        }
        /// <summary>
        /// Gets the current visual studio's solution DTE2
        /// </summary>
        private static DTE2 GetCurrent()
        {
            List<DTE2> dte2s = new List<DTE2>();
            IRunningObjectTable rot;
            GetRunningObjectTable(0, out rot);
            IEnumMoniker enumMoniker;
            rot.EnumRunning(out enumMoniker);
            enumMoniker.Reset();
            IntPtr fetched = IntPtr.Zero;
            IMoniker[] moniker = new IMoniker[1];
            while (enumMoniker.Next(1, moniker, fetched) == 0)
            {
                IBindCtx bindCtx;
                CreateBindCtx(0, out bindCtx);
                string displayName;
                moniker[0].GetDisplayName(bindCtx, null, out displayName);
                // add all VisualStudio ROT entries to list
                if (displayName.StartsWith("!VisualStudio"))
                {
                    object comObject;
                    rot.GetObject(moniker[0], out comObject);
                    dte2s.Add((DTE2)comObject);
                }
            }
            // get path of the executing assembly (assembly that holds this code) - you may need to adapt that to your setup
            string thisPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // compare dte solution paths to find best match
            KeyValuePair<DTE2, int> maxMatch = new KeyValuePair<DTE2, int>(null, 0);
            foreach (DTE2 dte2 in dte2s)
            {
                int matching = GetMatchingCharsFromStart(thisPath, dte2.Solution.FullName);
                if (matching > maxMatch.Value)
                    maxMatch = new KeyValuePair<DTE2, int>(dte2, matching);
            }
            return (DTE2)maxMatch.Key;
        }
        /// <summary>
        /// Gets index of first non-equal char for two strings
        /// Not case sensitive.
        /// </summary>
        private static int GetMatchingCharsFromStart(string a, string b)
        {
            a = (a ?? string.Empty).ToLower();
            b = (b ?? string.Empty).ToLower();
            int matching = 0;
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (!char.Equals(a[i], b[i]))
                    break;
 
                matching++;
            }
            return matching;
        }
    }
