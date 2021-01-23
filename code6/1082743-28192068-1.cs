    dataSetRow = theData.Rows[0];
    MyModel = new CustomModel
                  {
                      MyModel.Column1 = GetRowValue(dataSetRow, "Column1"),
                      MyModel.Column2 = GetRowValue(dataSetRow, "Column2"),
                      ...
                  };
