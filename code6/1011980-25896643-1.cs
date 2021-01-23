        private static void CopyCharts(Excel.Workbook wbIn, Excel.Workbook wbOut)
        {
            Excel.Worksheet wsOutAfter = (Excel.Worksheet)wbOut.Sheets["Plot Items"];
            foreach (Excel.Chart c in wbIn.Charts)
            {
                c.Copy(Type.Missing, wsOutAfter);
            }
            // break external links in new charts
            Regex externalLink = new Regex(@"\[" + wbIn.Name + @"\]");
            foreach (Excel.Chart cOut in wbOut.Charts)
            {
                Excel.SeriesCollection scOut = (Excel.SeriesCollection)cOut.SeriesCollection();
                foreach (Excel.Series sOut in scOut)
                {
                    string formula = sOut.Formula;
                    formula = externalLink.Replace(formula, "");
                    sOut.Formula = formula;
                }
            }
        }
