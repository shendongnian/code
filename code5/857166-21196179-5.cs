    public object Execute(GameConfiguration request)
    {
        // Original data
        string respValue = request.puid ?? "0";
        return new GameConfigurationResponse
        {
            level = new List<Level> {
                new Level { level = 1, points = 0, name = "Some" },
                new Level { level = 2, points = 50, name = "Second level" }, 
                new Level { level = 3, points = 100, name = "Third level" }
            }
        };
    }
