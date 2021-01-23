    if (!IsWriteEnabled || !IsReadEnabled) 
            {
               var tb = tr.GetObject(this.ObjectId, OpenMode.ForRead) as Table;
               // tr.GetObject(this.ObjectId, OpenMode.ForWrite);
               tb.UpgradeOpen();
               for (int i = 1; i < NumRows; i++)
               {
                   if (Cells[i, 0].GetTextString(FormatOption.ForExpression).Equals(openingName))
                   {
                     tb.DeleteRows(i, 1);
                    }
                }
                tb.DowngradeOpen();
             }
    
