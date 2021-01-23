     public class CustomTextBox :TextBox
    {
        private static List<CustomTextBox> CustomTextBoxList = new List<CustomTextBox>();
        public static async void ValidateAll()
        {
            foreach (CustomTextBox MyCustomTextBox in CustomTextBoxList)
            {
                ****PERFORM VALIDATION****
            }
        }
        public CustomTextBox ()
        {
            CustomTextBoxList.Add(this);
        }
        ~CustomTextBox()
        {
            CustomTextBoxList.Remove(this);
        }
    }
