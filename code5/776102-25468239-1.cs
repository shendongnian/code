    public override void Input0_ProcessInputRow(Input0Buffer InputBufferRow)
    {
         //For InputBuffer
        foreach (IDTSInputColumn100 iColumn in this.ComponentMetaData.InputCollection[0].InputColumnCollection)
        {
            string iName = iColumn.Name;
            string iType = iColumn.DataType.ToString();
            string iLength = iColumn.Length.ToString();
            string iPrecision = iColumn.Precision.ToString();
        }
        //For OutputBuffer
        foreach (IDTSOutputColumn100 oColumn in this.ComponentMetaData.OutputCollection[0].OutputColumnCollection)
        {
            string oName = oColumn.Name;
            string oType = oColumn.DataType.ToString();
            string oLength = oColumn.Length.ToString();
            string oPrecision = oColumn.Precision.ToString();
        }
     }
