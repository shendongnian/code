    public static class CustomMessageBox {
      public static void Show(string message) {
        MessageBox.Show(String.Format("{0} {1}", message, DateTime.Now.ToString()));
      }
    }
