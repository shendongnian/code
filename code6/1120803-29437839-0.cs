    public class MyObject 
    {
        public DateTime Date { get; set; }
        
        public void SetDate(string date) 
        {
            this.Date = DateTime.Parse(date);
        }    
    }
