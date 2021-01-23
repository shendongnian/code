    for (int i = 0; i < range.Rows.Count; i++) {
            range.Rows[i].Value = lines[i];
            range.Rows[i].TextToColumns(
                range.Rows[i],
                Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited,
                Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierNone,
                false,
                true
            );          
        }
