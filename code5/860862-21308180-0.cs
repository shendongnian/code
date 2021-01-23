    namespace WebApplication.Custom.Controls
    {
        public class TrimmedTextBuox : TextBox
        {
            public override string Text
            {
                get
                {                
                    return base.Text;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                        base.Text = value.Trim();
                }
            }
        }
    }
