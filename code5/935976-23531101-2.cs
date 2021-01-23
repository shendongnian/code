    public class QuestionAnswerPair
    {
        public String Question { get; set; }
        public String Answer { get; set; }
    }
    .....
    ObservableCollection<QuestionAnswerPair> Questions { get; set; }
 
    .....  
 
    String csv = String.Join(Questions.Select(qAndA => String.Format("{0};{1}\n", qAndA.Question , qAndA.Answer)).ToArray(), ','); 
    System.IO.File.WriteAllText(@"C:\Test\Samplec.csv", csv);
