    [TestMethod]
    public void TestRegex()
    {
        var input = "select * from cable where exchange like " +
                    "'%{Enter Exchange:}%' and Type like '%{Enter Type:}%'";
        var result = Regex.Matches(input, @"%\{(.+?)\}%")
                .Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToArray();
        result.Should().HaveCount(2);
        result.Should().Contain("Enter Exchange:");
        result.Should().Contain("Enter Type:");
    }
