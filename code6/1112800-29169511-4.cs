    public class ModelDeserialize
    {
        private string _elementsSeparator;
        private string _dataSeparator;
        private int _valueIdx;
        public ModelDeserialize(string elementsSeparator, string dataSeparator, int valueIdx)
        {
            _elementsSeparator = elementsSeparator;
            _dataSeparator = dataSeparator;
            _valueIdx = valueIdx;
        }
        public Model Deserialize(string data)
        {
            var idx = 0;
            var separatedElements = data.Split(new[] { _elementsSeparator }, StringSplitOptions.RemoveEmptyEntries);
            var model = new Model();
            model.Opp = Int32.Parse(Value(separatedElements[idx++]));
            model.Member = Value(separatedElements[idx++]);
            model.Patient = Value(separatedElements[idx++]);
            model.Room = Value(separatedElements[idx++]);
            model.Time = Value(separatedElements[idx]);
            return model;
        }
        private string Value(string element)
        {
            return element.Split(new[] { _dataSeparator }, StringSplitOptions.None)[_valueIdx].Trim();
        }
    }
