    public class Question {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionNr { get; set; }
        public string Image { get; set; }
        public TestClass Test { get; set; }
    }
    
    public class TestClass {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Public { get; set; }
        public int SubmittedTest { get; set; }
    }
    
    
    // for your event, when creating Question, just do the same for Test, embedded!
    protected void Submitquestionbtn_Click(object sender, EventArgs e) {
        var result = new QuestionService().AddQuestion(
            new Question {
                Text = questionText.Text,
                QuestionNr = int.Parse(questionOrder.Text),
                Image = "",
                Test = new TestClass {
                    Id = -1,
                    Name = "",
                    Description = "",
                    Public = "",
                    SubmittedTest = -1
                }
            }
        );
        Response.Redirect("EditQuiz.aspx?success");
    }
