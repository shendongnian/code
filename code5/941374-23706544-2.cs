    [Fact]
    public void Test()
    {
        string tinyJsonl = "{\"Message\":\"SUCCESS\",\"Result\":null}";
        var defaultProfile = JsonConvert.DeserializeObject<ProfileModel>(tinyJsonl, new MyJsonConverter());
        Assert.False(defaultProfile.DataLayout.Vertical);
    
        string fullJson = "{\"Message\":\"SUCCESS\",\"Result\":{\"DataLayout\":{\"Vertical\":true}}}";
        var customProfile = JsonConvert.DeserializeObject<ProfileModel>(fullJson, new MyJsonConverter());
        Assert.True(customProfile.DataLayout.Vertical);
    }
