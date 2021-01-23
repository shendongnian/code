    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        TaskExt.Log("A1");
        await AnotherClass.MethodAsync().ConfigureAwait(false);
        TaskExt.Log("A2");
    }
    public class AnotherClass
    {
        public static async Task MethodAsync()
        {
            TaskExt.Log("B1");
            await SomeClass.SomeAsyncApi().ConfigureAwait(false);
            TaskExt.Log("B2");
        }
    }
    public class SomeClass
    {
        public static async Task<int> SomeAsyncApi()
        {
            TaskExt.Log("X1");
            await Task.Delay(1000).WithCompletionLog(step: "X1.5").ConfigureAwait(false);
            TaskExt.Log("X2");
            return 42;
        }
    }
