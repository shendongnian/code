    public void FindTextAndChangeColor(string text, Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet)
        {
            Microsoft.Office.Interop.Excel.Range currentFind = null;
            Microsoft.Office.Interop.Excel.Range firstFind = null;
            // Find the first occurrence of the passed-in text
            currentFind = excelWorkSheet.Cells.Find(text, Missing.Value, Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
                Microsoft.Office.Interop.Excel.XlLookAt.xlPart, Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext,
                false, Missing.Value, Missing.Value);
            while (currentFind != null)
            {
                // Keep track of the first range we find
                if (firstFind == null)
                {
                    firstFind = currentFind;
                }
                else if (currentFind.get_Address(Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1,
                    Missing.Value, Missing.Value) ==
                    firstFind.get_Address(Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1,
                    Missing.Value, Missing.Value))
                {
                    // We didn't move to a new range so we're done
                    break;
                }
                // We know our text is in first cell of this range, so we need to narrow down its position
                string searchResult = currentFind.get_Range("A1").Value2.ToString();
                int startPos = searchResult.IndexOf(text);
                // Set the text in the cell to bold
                currentFind.get_Range("A1").Characters[startPos + 1, text.Length].Font.Color = Color.Red;
                // Move to the next find
                currentFind = excelWorkSheet.Cells.FindNext(currentFind);
            }
        }
