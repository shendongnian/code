    public UserControlValue Value
        {
            get
            {
                return new UserControlValue(DropDownList1.SelectedValue, TextBox1.Text);
            }
        }
    public class UserControlValue
    {
        public UserControlValue(string property1, string property2)
        {
            this.property1 = property1;
            this.property2 = property2;
        }
        public string property1 {get; set;}
        public string property2 {get; set;}
    }
