    public class MyViewModel {
        public DateTime Date { get; set; }
        public string DisplayedDate
        {
            get
            {
                return Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }
    }
