    for(int j =2; j <=9; j++) //Loop through columns
    {
       for(int i = 3; i <= 12; i++) // Loop through rows
       {
       // gets only the current cell as range
       ExcelRange rng = worksheet.Cells[i, j, i, j]; 
       ExcelAddress address = new ExcelAddress(rng.Address);
       // Get the value of the current cell
       if(Convert.ToDouble(worksheet.Cells[i, j].Value) >= 4.0)
       {
          var v = worksheet.ConditionalFormatting.AddThreeIconSet(address, eExcelconditionalFormatting3IconSetType.Arrows);
          v.Reverse = true;
          v.Icon1.Type = eExcelConditionalFormattingValueObjectType.Num;
       }
       else if(Convert.ToDouble(workSheet.Cells[i, j].Value) > 1.0 && Convert.ToDouble(workSheet.Cells[i, j].Value) < 4.0)
       {
          var v = worksheet.ConditionalFormatting.AddThreeIconSet(address , eExcelconditionalFormatting3IconsSetType.Arrows);
          v.Icon3.Type = eExcelConditionalFormattingValueObjectType.Num;
       }
       else (Convert.ToDouble(workSheet.Cells[i, j].Value)  < 1.0)
       {
          var v = worksheet.ConditionalFormatting.AddThreeIconSet(address , eExcelconditionalFormatting3IconsSetType.Arrows);
          v.Icon2.Type = eExcelConditionalFormattingValueObjectType.Num;
       }
    }
    }
