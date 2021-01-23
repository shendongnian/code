    public class MyCommonClass
    {
        public static void ClearTextBoxes(TextBoxes[] tb)
        {
            if (tb != null)
            {
                for(int i = 0; i < tb.Count; i++)
                    tb[i].Text = String.Empty;
            }
        }
    }
