    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void GetArraysTest()
        {
            var target = new byte[] { 0x01, 0x02, 0x03 };
            var expected = new byte[] { 0x01, 0x02, 0x03, 0x00};
            var size = 3;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var arrays = Form1.GetArrays(target, size);
            stopWatch.Stop();
            foreach(var array in arrays)
            {
                for(int i = 0; i < expected.Count(); i++)
                {
                    Assert.AreEqual(expected[i], array[i]);
                }
            }
            Console.WriteLine(string.Format("{0}ns", stopWatch.Elapsed.TotalMilliseconds * 1000000));
        }
    }
