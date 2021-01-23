    [TestClass]
    public class ChangeDetectUnitTest
    {
        public class ChangeDetectList<T>
        {
            private readonly List<T> list = new List<T>();
            private readonly ISet<T> hashes = new HashSet<T>();
            public bool HasChanged(T t)
            {
                return !hashes.Contains(t);
            }
            public void Add(T t)
            {
                list.Add(t);
                hashes.Add(t);
            }
            public void Reset()
            {
                hashes.Clear();
                foreach (var t in list)
                    hashes.Add(t);
            }
        }
        public class PlayerInfo
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public override int GetHashCode()
            {
                //every field that you want to detect must feature in the hashcode
                return (Name ?? "").GetHashCode() * 31 + Score;
            }
            public override bool Equals(object obj)
            {
                return Equals(obj as PlayerInfo);
            }
            public bool Equals(PlayerInfo other)
            {
                if (other == null) return false;
                return Equals(other.Name, Name) && Score == Score;
            }
        }
        private ChangeDetectList<PlayerInfo> list;
        [TestInitialize]
        public void Setup()
        {
            list = new ChangeDetectList<PlayerInfo>();
        }
        [TestMethod]
        public void Can_add()
        {
            var p1 = new PlayerInfo();
            list.Add(p1);
            Assert.IsFalse(list.HasChanged(p1));
        }
        [TestMethod]
        public void Can_detect_change()
        {
            var p1 = new PlayerInfo();
            list.Add(p1);
            p1.Name = "weston";
            Assert.IsTrue(list.HasChanged(p1));
        }
        [TestMethod]
        public void Can_reset_change()
        {
            var p1 = new PlayerInfo();
            list.Add(p1);
            p1.Name = "weston";
            list.Reset();
            Assert.IsFalse(list.HasChanged(p1));
        }
    }
