    public class OptionRadioButtonList : RadioButtonList
    {
        public EventHandler SelectionChangeEventHandler;
        public OptionRadioButtonList()
        {
            
            RepeatDirection = RepeatDirection.Vertical;
            AutoPostBack = true;
            Items.Add(new ListItem("YES", "YES"));
            Items.Add(new ListItem("NO", "NO"));
            CssClass = "rbList";
        }
    
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            var handler = SelectionChangeEventHandler;
            if (handler == null) return;
            handler(this, e);
        }
    }
