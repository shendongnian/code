    public sealed class ReadableInt {
        int _value;
        IPrivateConsumer _privateConsumer;
        public ReadableInt(IPrivateConsumer privateConsumer, Action<PrivateApi> privateConsumerInitializer) {
            _privateConsumer = privateConsumer;
            var proxy = new PrivateApi(this);
            privateConsumerInitializer(proxy);
        }
        public int GetValue() {
            return _value;
        }        
        private void SetValue(int value) {
            _value = value;
            _privateConsumer.OnValueChanged();
        }
        public interface IPrivateConsumer {
            void OnValueChanged();
        }
        public class PrivateApi {
            ReadableInt _readableInt;
            internal PrivateApi(ReadableInt publicApi) {
                _readableInt = publicApi;
            }
            public void SetValue(int value) {
                _readableInt.SetValue(value);
            }
        }
    }
