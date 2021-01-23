    [Test]
    public void BinaryStringToValues()
    {
        const string binaryString = "111";
        var values = new List<int>();
        for (var i = 0; i < binaryString.Length; i++)
        {
            if (binaryString[binaryString.Length - i - 1] == '0')
            {
                continue;
            }
            values.Add(1 << i);
        }
        Assert.AreEqual(1, values[0]);
        Assert.AreEqual(2, values[1]);
        Assert.AreEqual(4, values[2]);
    }
