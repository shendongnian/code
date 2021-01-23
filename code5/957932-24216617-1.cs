    public sealed class WritableInt : ReadableInt.IPrivateConsumer {
        ReadableInt _readableInt;
        ReadableInt.PrivateApi _privateApi;
        public WritableInt() {
            _readableInt = new ReadableInt(this, Initialize);
        }
        void Initialize(ReadableInt.PrivateApi privateApi) {
            _privateApi = privateApi;
        }
        public ReadableInt ReadOnlyInt { get { return _readableInt; } }
        public void SetValue(int value) {
            _privateApi.SetValue(value);
        }
        void ReadableInt.IPrivateConsumer.OnValueChanged() {
            Console.WriteLine("Value changed!");
        }
    }
