     public class SomeClass
     {
          private readonly IConsoleThemePicker _consoleThemePicker;
          public SomeClass(IConsoleThemePicker consoleThemePicker)
          {
               _consoleThemePicker = consoleThemePicker;
          }
          public void SomeMethod()
          {
               var theme = _consoleThemePicker.GetCurrentConsoleTheme();
               // use theme
          }
     }
