    [Test]
    public void GenerateStrings()
    {
        var gen1 = new ConcurrentStringGenerator("0123456789", 9);
        for (int i = 0; i < 100; i++)
        {
            var str = gen1.Reserve();
            Console.WriteLine(int.Parse(str).ToString("000-000-000"));
            Assert.True(gen1.Release(str));
        }
        
        var gen2 = new ConcurrentStringGenerator("ABCDEFGHJKLMNPQRSTUVWXYZ", 3);
        for (int i = 0; i < 100; i++)
        {
            var str = gen2.Reserve();
            Console.WriteLine(str);
            Assert.True(gen2.Release(str));
        }
    }
