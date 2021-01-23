    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void GetArraysTest()
        {
            var expected = new byte[] { 0x30, 0x31, 0x32, 0x00 };
            var size = 3;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var iso_8859_5 = System.Text.Encoding.GetEncoding("iso-8859-5");
            var target = iso_8859_5.GetBytes("012");
            var arrays = Form1.GetArrays(target, size);
            BitConverter.ToUInt32(arrays[0], 0);
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
