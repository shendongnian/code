                workSheet.Cells[nRows + 1, 3] = DateTime.Today;
                Range sourceRange = workSheet.Cells[nRows, 3];
                sourceRange.Copy(Type.Missing);
                Range destinationRange = workSheet.Cells[nRows + 1, 3];
                destinationRange.PasteSpecial(XlPasteType.xlPasteFormats, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                destinationRange.PasteSpecial(XlPasteType.xlPasteFormulas, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
