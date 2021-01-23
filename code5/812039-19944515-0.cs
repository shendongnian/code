    public class Category
    {
    	public Category() { }
    
        public string name { get; set; }
        public Answer first { get; set; }
        public Answer second { get; set; }
        public Answer third { get; set; }
        public Answer fourth { get; set; }
        public Answer fifth { get; set; }
    }
    
    public class Answer
    {
        public decimal points { get; set; }
        public string answer { get; set; }
        public string description { get; set; }
    
        public Answer(decimal points, string answer, string description)
    	{
            this.points = points;
            this.answer = answer;
            this.description = description;
    	}
    }
