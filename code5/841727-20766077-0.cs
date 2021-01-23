    public class Form1
    {
        public void inputTextBox_Changed(object sender, EventArgs e)
        {
            object input=(sender as Control).Text;
            if (sender.IsNumeric())
            {
            }
        }
    }
    public static class CustomTools
    {
        public static bool IsNumeric(this object item)
        {
            if (item==null) return false;
            double result;
            return double.TryParse(item.ToString(), out result);
        }
    }
