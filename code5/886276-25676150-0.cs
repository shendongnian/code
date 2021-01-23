    public class PaddedIntConverter:ConverterBase
    {
        private int _size;
        public PaddedIntConverter(int size)
        {
            _size = size;
        }
        public override object StringToField(string from)
        {
 	        return int.Parse(from);
        }
        
        public override string FieldToString(object from)
        {
 	        return from.ToString().PadLeft(_size,'0');
        }
    }
