    public partial class MainPage : UserControl
    {
            private List<Quiz> quizzes;
    
            public MainPage()
            {
                InitializeComponent();
    
                var xmlUri = new Uri("http://yoursite.com/quiz.xml");
                var downloader = new WebClient();
        
                downloader.OpenReadCompleted += new OpenReadCompletedEventHandler(downloader_OpenReadCompleted);
                downloader.OpenReadAsync(xmlUri);
            }
    
    
            void downloader_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
            {
               if (e.Error == null)
               {
                  Stream responseStream = e.Result;
    
                   using (var reader = XmlReader.Create(responseStream))
                   {
                      var doc = XDocument.Read(reader);
    
                      quizzes = doc.Descendants("question")
                                .Select(q => new Quiz 
                                {
                                   QuestionText = q.Element("questionText").Value, 
                                   Level = q.Element("LEVEL").Value,
                                   AnswerList = q.Descendants("incorrect")
                                                 .Select(i => new Answers 
                                                 { 
                                                    IsCorrect = false, 
                                                    AnswerName = i.Value 
                                                 })
                                                 .Union(
                                                    q.Descendants("correct")
                                                     .Select(i => new Answers 
                                                     { 
                                                        IsCorrect = true, 
                                                        AnswerName = i.Value 
                                                 })).ToList()
    		
                                }).ToList();      
                   }
               }
            }         
        }
