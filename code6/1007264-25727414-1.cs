    public static SailingParameters Load(string filename) {
        return XmlUtils.Load<SailingParameters>(filename, () => new SailingParameters {
            MaxDepth = 13000;
            MaxSpeedKnots = 15;
        });
    }
