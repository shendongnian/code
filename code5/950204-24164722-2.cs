    // Putting MAX and MIN in both of them will be useful later, just trust me
    public enum MenuOptions
    {
        MIN = -1,
        PLAY,
        LOAD_SAVE,
        OPTIONS,
        QUIT,
        MAX
    }
    public enum OptionsOptions // Yes, i know its not the best name
    {
        MIN = -1,
        MUTE_SOUND,
        MUTE_VOLUME,
        RAISE_LOWER_VOLUME,
        MAX
    }
    // Create your variables in your class at the top
    private MenuOptions m_CurrentMenuOption;
    private OptionsOptions m_CurrentOptionsOption;
    private Bool m_InOptions; // We will need this shortly
