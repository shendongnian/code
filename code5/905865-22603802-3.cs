    class FrequencyListItem : System.Web.UI.WebControls.ListItem.ListItem {
        private Frequency _Frequency;
    
        public Frequency Frequency {
            get { return _Frequency }
        }
    
        public FrequencyListItem (Frequency f) {
            this._Frequency = f;
            this.Text = f.ToDescriptiveTextUsingAttributes();
            this.Value = f.ToString();
        }
    }
