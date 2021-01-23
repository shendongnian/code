    /// <summary>
    /// Get AppBarButton of AppBar - extension method
    /// </summary>
    /// <param name="index">index of target AppBarButton</param>
    /// <returns>AppBarButton of desired index</returns>
    public static AppBarButton PButton(this AppBar appBar, int index) { return (appBar as CommandBar).PrimaryCommands[index] as AppBarButton; }
