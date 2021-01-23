      private static void Error(object sender, ErrorEventArgs errorEventArgs)
      {
          var ex = errorEventArgs.ErrorContext.Error;
          if (ex.GetType() == typeof(JsonSerializationException)) {
             if (ex.InnerException != null) ex = ex.InnerException();
             Console.WriteLine(ex.Message);
          // etc...
