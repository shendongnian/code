    public class ScalarValue: DataValue {
        public ScalarValue() {
            DimensionCount = 1;
            Dimensions = new [] { 1 };
        }
        public override void ReadValues(string header, StreamReader reader) {
            base.ReadValues(header, reader);
            // Do custom logic for reading a scalar here.
        }
    }
