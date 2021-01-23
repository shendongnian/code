    public override void Input0_ProcessInputRow(Input0Buffer inputBufferRow)
         {
        foreach (IDTSInputColumn100 column in this.ComponentMetaData.InputCollection[0].InputColumnCollection)
                { 
                  PropertyInfo columnValue = inputBufferRow.GetType().GetProperty(column.Name);
                }
           }
