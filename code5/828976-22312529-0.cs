    static ICellStyle _doubleCellStyle = null;
    static ICellStyle _intCellStyle    = null;
    static void SettingDifferentCellFormat( HSSFWorkbook hssfOutputWorkBook, ISheet orderedSheet, ISheet unorderedSheet ) {
    
       //short doubleFormat = hssfOutputWorkBook.CreateDataFormat().GetFormat( "#,##0.###" );
       //short intFormat = hssfOutputWorkBook.CreateDataFormat().GetFormat( "#,##0" );
    
       if ( _doubleCellStyle == null ) { 
          _doubleCellStyle = hssfOutputWorkBook.CreateCellStyle();
          _doubleCellStyle.DataFormat = hssfOutputWorkBook.CreateDataFormat().GetFormat( "#,##0.###" );
       }
    
       if ( _intCellStyle == null ) { 
          _intCellStyle = hssfOutputWorkBook.CreateCellStyle();
          _intCellStyle.DataFormat = hssfOutputWorkBook.CreateDataFormat().GetFormat( "#,##0" ); 
       }
    
       for ( int i = 0; i <= unorderedSheet.LastRowNum; i++ ) {
          
          NPOI.SS.UserModel.IRow newRow = orderedSheet.CreateRow( i );
          NPOI.SS.UserModel.IRow oldRow = unorderedSheet.GetRow( i );
    
          const int mapping_n_ = 0;
    
          if ( oldRow != null ) {
             foreach ( ICell oldCell in oldRow.Cells ) {
    
                ICell newCell = newRow.CreateCell( mapping_n_ );
                bool numberHasDecimals = true;
    
                switch ( oldCell.CellType ) {
                  
                   case CellType.NUMERIC:
                      
                      newCell.SetCellType( CellType.NUMERIC );
                      newCell.SetCellValue( oldCell.NumericCellValue );
    
                      if ( numberHasDecimals ) {
                         //newCell.CellStyle.DataFormat = doubleFormat;
                         newCell.CellStyle = _doubleCellStyle;
                      } else {
                         //newCell.CellStyle.DataFormat = intFormat;
                         newCell.CellStyle = _intCellStyle;
                      }
                      break;
                   default:
                      newCell.SetCellValue( oldCell.ToString() );
                      break;
                }
             }
          }
       }
    
    }//SettingDifferentCellFormat
