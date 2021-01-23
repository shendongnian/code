     public interface IConsoleThemePicker
     {
          ConsoleTheme GetCurrentConsoleTheme();
     }
     public class DefaultConsoleThemePicker : IConsoleThemePicker
     {
          public ConsoleTheme GetCurrentConsoleTheme();
     }
