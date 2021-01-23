    public class NodeC_Elem
    {
        [XmlIgnore]
        public double? value { get; set; }
        [XmlText]
        public string StringValue 
        {
            get
            {
                if (value == null)
                    return null;
                return XmlConvert.ToString(value.Value);
            }
            set
            {
                if (value == null)
                {
                    this.value = null;
                    return;
                }
                this.value = XmlConvert.ToDouble(value);
            }
        }
    }
