    private static MyImage LoadFirstWay(string name) {
        return ...
    }
    private static MyImage LoadSecondWay(string name) {
        return ...
    }
    private static MyImage LoadThirdWay(string name) {
        return ...
    }
    ...
    public MyImage LoadImage(string name) {
        Func<string,MyImage>[] waysToLoad = new Func<string,MyImage>[] {
            LoadFirstWay
        ,   LoadSecondWay
        ,   LoadThirdWay
        };
        foreach (var way in waysToLoad) {
            try {
                return way(name);
            } catch (Exception e) {
                Console.Error("Warning: loading of '{0}' failed, {1}", name, e.Message);
            }
        }
        return null;
    }
