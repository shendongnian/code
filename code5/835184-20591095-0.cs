    class Button
    {
      public Button(string label) {}
      public event Action Clicked;
    }
    class Program
    {
      public static void Main(string[] args)
      {
        var settingsButton = new Button("Settings");
        settingsButton.Clicked += () =>
        {
          // open settings view
        };
      }
    }
