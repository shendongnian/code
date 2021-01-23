    [TestClass]
    public class Test
    {
        private readonly List<string> _originalFrames = new List<string>();
        public Test()
        {
            // 30 FPS for 10 seconds
            for (int f = 0; f < 300; f++)
            {
                _originalFrames.Add(string.Format("{0:0000000}.png", f));
            }
        }
        [TestMethod]
        public void Should_set_default_values()
        {
            var scaler = new FramerateScaler<string>(30, 30, _originalFrames, 10);
            Assert.AreEqual(30, scaler.InputRate);
            Assert.AreEqual(30, scaler.OutputRate);
            Assert.AreEqual(10, scaler.StartIndex);
            Assert.AreEqual(_originalFrames.ElementAt(10), scaler.First());
        }
        [TestMethod]
        public void Scale_from_same_is_idempotent()
        {
            var scaler = new FramerateScaler<string>(30, 30, _originalFrames);
            Assert.AreEqual(scaler.InputDuration, scaler.OutputDuration);
            Assert.AreEqual(_originalFrames.Count, scaler.Count());
            Assert.IsTrue(_originalFrames.SequenceEqual(scaler));
        }
        [TestMethod]
        public void Scale_from_same_offset_by_half_is_idempotent()
        {
            var scaler = new FramerateScaler<string>(
                30, 30, _originalFrames, _originalFrames.Count / 2);
            Assert.AreEqual(150, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            Assert.IsTrue(_originalFrames
                .Skip(150)
                .SequenceEqual(scaler));
        }
        [TestMethod]
        public void Scale_from_30_to_60()
        {
            var scaler = new FramerateScaler<string>(30, 60, _originalFrames);
            
            Assert.AreEqual(600, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            var result = scaler.ToList();
            Assert.IsTrue(_originalFrames
                .Concat(_originalFrames)
                .OrderBy(x => x)
                .SequenceEqual(scaler));
        }
        [TestMethod]
        public void Scale_from_30_to_60_offset_by_half()
        {
            var scaler = new FramerateScaler<string>(
                30, 60, _originalFrames, _originalFrames.Count / 2);
            Assert.AreEqual(300, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            Assert.IsTrue(_originalFrames
                .Skip(150)
                .Concat(_originalFrames.Skip(150))
                .OrderBy(x => x)
                .SequenceEqual(scaler));
        }
        [TestMethod]
        public void Scale_from_30_to_100()
        {
            var scaler = new FramerateScaler<string>(30, 100, _originalFrames);
            Assert.AreEqual(1000, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            // 000 - 111 - 2222 ...
            Assert.IsTrue(scaler.PatternIs(0, 0, 0, 1, 1, 1, 2, 2, 2, 2));
        }
        [TestMethod]
        public void Scale_from_30_to_100_offset_by_half()
        {
            var scaler = new FramerateScaler<string>(
                30, 100, _originalFrames, _originalFrames.Count / 2);
            Assert.AreEqual(500, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            // 000 - 111 - 2222 ...
            Assert.IsTrue(scaler.PatternIs(0, 0, 0, 1, 1, 1, 2, 2, 2, 2));
        }
        [TestMethod]
        public void Scale_from_24p_to_ntsc()
        {
            var scaler = new FramerateScaler<string>(23.967, 29.97, _originalFrames);
            Assert.AreEqual(375, scaler.Count());
            Assert.AreEqual(
                scaler.OutputDuration.TotalMilliseconds, 
                scaler.InputDuration.TotalMilliseconds, delta: 4);
            // 0 - 1 - 2 - 33 ...
            Assert.IsTrue(scaler.PatternIs(0, 1, 2, 3, 3));
        }
        [TestMethod]
        public void Scale_from_30_to_15()
        {
            var scaler = new FramerateScaler<string>(30, 15, _originalFrames);
            Assert.AreEqual(150, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            Assert.IsTrue(_originalFrames
                .Where((item, index) => index % 2 == 1)
                .SequenceEqual(scaler));
        }
        [TestMethod]
        public void Scale_from_30_to_15_offset_by_half()
        {
            var scaler = new FramerateScaler<string>(30, 15, _originalFrames, 150);
            Assert.AreEqual(75, scaler.Count());
            Assert.AreEqual(scaler.OutputDuration, scaler.InputDuration);
            Assert.IsTrue(_originalFrames
                .Skip(150)
                .Where((item, index) => index % 2 == 1)
                .SequenceEqual(scaler));
        }
    }
    static class Extensions
    {
        public static bool PatternIs<T>(this IEnumerable<T> source, params int[] pattern)
        {
            foreach (var chunk in source.Chunkify(pattern.Length))
            {
                for (var i = 0; i < chunk.Length; i++)
                    if (!chunk.ElementAt(i).Equals(
                        chunk.Distinct().ElementAt(pattern[i])))
                        return false;
            }
            return true;
        }
        // http://stackoverflow.com/a/3210961/3191599
        public static IEnumerable<T[]> Chunkify<T>(this IEnumerable<T> source, int size)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (size < 1) throw new ArgumentOutOfRangeException("size");
            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var chunk = new T[size];
                    chunk[0] = iter.Current;
                    for (int i = 1; i < size && iter.MoveNext(); i++)
                    {
                        chunk[i] = iter.Current;
                    }
                    yield return chunk;
                }
            }
        }
    }
