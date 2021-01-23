    MyDataset.tblShipperRow _newRow = _tblShipper.NewtblShipperRow();
    foreach(tblParsedDataRow _row in _parsedDataForShipper.Rows)
    {    
          foreach (var property in _newRow.GetType().GetProperties())
          {
                if (_row.FieldName == property.Name)
                {
                     property.SetValue(_newRow, _row.FieldValue, null);
                     break;
                }
          }
    }
 
