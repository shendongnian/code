    [TestMethod]
    public void SplitString()
    {
        string splitMe = "KeyA : SubComponent { SubKey : SubValue } KeyB:This's is a string";
        string pattern = "^(.*):(.*)({.*})(.*):(.*)";
        Match match = Regex.Match(splitMe, pattern);
        Assert.IsTrue(match.Success);
        Assert.AreEqual(6, match.Groups.Count); // 1st group is the entire match
        Assert.AreEqual("KeyA", match.Groups[1].Value.Trim());
        Assert.AreEqual("SubComponent", match.Groups[2].Value.Trim());
        Assert.AreEqual("{ SubKey : SubValue }", match.Groups[3].Value.Trim());
        Assert.AreEqual("KeyB", match.Groups[4].Value.Trim());
        Assert.AreEqual("This's is a string", match.Groups[5].Value.Trim());
    }
