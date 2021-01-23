    public class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    public void func1()
    {
         MessageDialogHelper.Show("Message","Title");
    }
