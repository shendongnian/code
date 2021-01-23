    public enum Quality
    {
        VeryLow,
        Low,
        Medium,
        High,
        Maximum,
    }
    IEnumerable<Quality> qualities = new List<Quality>
    {
        Quality.Low,
        Quality.Medium,
        Quality.Maximum
    };
    Quality preferedQuality = Quality.High;
    Quality actualQuality = qualities
        .TakeWhile(quality => quality <= preferedQuality) // arrow phun
        .Max();
    Assert.AreEqual(Quality.Medium, actualQuality);
