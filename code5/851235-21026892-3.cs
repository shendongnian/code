    [Serializable]
    public class Question // Implement INotifyPropertyChanged correctly here
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
    }
