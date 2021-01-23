    public override void Input0_ProcessInputRow(Input0Buffer InputBufferRow)
    {
        foreach (IDTSInputColumn100 column in this.ComponentMetaData.InputCollection[0].InputColumnCollection)
        {
            string name = column.Name;
            string type = column.DataType.ToString();
            string length = column.Length.ToString();
            string precision = column.Precision.ToString();
        }
     }
