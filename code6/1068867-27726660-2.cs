    public class LayerCodePair {
        public string Code1 {get;set;}
        public string Code2 {get;set;}
    } // declared outside of method
    ...
    List<LayerCodePair> values = new List<LayerCodePair>();
    //...
    if (!values.Any(v=> v.Code1 == f.ColumnValues[layercode].ToString()) && !values.Any(v=>v.Code2 == f.ColumnValues[layercode2].ToString()))
    {
        values.Add(new LayerCodePair{ 
            Code1 = f.ColumnValues[layercode].ToString(),
            Code2 = f.ColumnValues[layercode2].ToString()
        });
    }
