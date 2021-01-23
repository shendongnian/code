    class FrequencyListItem : System.Web.UI.WebControls.ListItem.ListItem {
        private Frequency myFrequency;
    
        public Frequency Frequency {
            get { return myFrequency }
        }
    
        public FrequencyListItem (Frequency myFrequency) {
            this.myFrequency = myFrequency;
            this.Text = f.ToDescriptiveTextUsingAttributes();
            this.Value = f.ToString();
        }
    }
