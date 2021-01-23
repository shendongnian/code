    public class NotificationParameter {
        public NotificationParameter(string key, int value) {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public int Value { get; set; }
    }
    public interface IService {
        void Load(IEnumerable<NotificationParameter> parameters);
    }
    public class ClientClass {
        private readonly IService _service;
        public ClientClass(IService service) {
            _service = service;
        }
        public void Run(IEnumerable<NotificationParameter> parameters) {
            _service.Load(parameters);
        }
    }
    public class NotificationComparer : IEqualityComparer<NotificationParameter> {
        public bool Equals(NotificationParameter x, NotificationParameter y) {
            return Equals(x.Key, y.Key)
                && x.Value.Equals(y.Value);
        }
        public int GetHashCode(NotificationParameter obj) {
            return obj.Value.GetHashCode() ^ obj.Key.GetHashCode();
        }
    }
    private readonly static NotificationComparer Comparer = new NotificationComparer();
    [TestMethod]
    public void VerifyLoadCompareValues() {
        var parameters = new List<NotificationParameter> {
            new NotificationParameter("A", 1),
            new NotificationParameter("B", 2),
            new NotificationParameter("C", 3),
        };
        var expected = new List<NotificationParameter> {
            new NotificationParameter("A", 1),
            new NotificationParameter("B", 2),
            new NotificationParameter("C", 3),
        };
        var mockService = new Mock<IService>();
        var client = new ClientClass(mockService.Object);
        client.Run(parameters);
        mockService.Verify(mk => mk.Load(It.Is<IEnumerable<NotificationParameter>>( it=> it.SequenceEqual(expected,Comparer))));
    }
