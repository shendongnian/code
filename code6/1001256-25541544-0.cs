    [TestMethod]
    public void TestEncoding()
    {
        using (StringWriter sw = new StringWriter())
        {
            XmlWriter writer = new XmlTextWriter(sw);
            const string testChar = "\u8211";
            writer.WriteString(testChar);
            Assert.AreEqual(testChar, sw.ToString());
            writer.Close();
        }
    }
