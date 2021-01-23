    class RoseType
    {
    public const RoseType RedRose = new RoseType("Red Rose");
    public const RoseType WhiteRose = new RoseType("White Rose");
    public const RoseType BlackRose = new RoseType("Black Rose");
    public string Content { get; private set; }
    private RoseType(string content)
    {
      this.Content = content;
    }
    public override string ToString()
    {
    return this.Content;
    }
    }
