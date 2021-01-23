    public class MyCommonClass
    {
        public static void ClearTextBoxes(TextBoxes[] tb)
        {
            for(int i = 0; i < tb.Count; i++)
                tb[i].Text = String.Empty;
        }
    }
