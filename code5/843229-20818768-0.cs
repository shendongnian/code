    public partial class XTextBox : System.Web.UI.UserControl
    {
       
        [Category("Behavior"), Description("convert the current text to DateTime")]
        public DateTime? MyDate
        {
            get
            {
                return ChangeDate();
            }
            set
            {               
                tbText.Text =  ToDateString(value);
            }
        }
        private string ToDateString(DateTime? dt )
        {
            return dt.HasValue ? ((DateTime)dt).ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
        }
        private DateTime? ChangeDate()
        {
            DateTime dt;
            if (DateTime.TryParse(tbText.Text, out dt))
            {
                tbText.Attributes.Add("MyDate", tbText.Text);
                return dt;
            }
            tbText.Attributes.Add("MyDate", "");
            return null;
        }
    }
    
