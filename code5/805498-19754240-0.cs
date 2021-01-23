    [DataContract]
    public class ListItem {
        
        [DataMember]
        public String Title { get; set; }
        
        [DataMember]
        public bool Checked { get; set; }
    
        public ListItem(String title, bool isChecked=false) {
            Title = title;
            Checked = isChecked;
        }
    
        private ListItem() { }
    }
