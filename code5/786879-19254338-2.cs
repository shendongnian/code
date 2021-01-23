    public class NflGameContent : ViewModelBase
    {
        private Thread _worker;
        
        public NflGameContent(int gameID){
            _worker = new Thread(() => UpdateScores(gameID));
            _worker.Start();
        }
        private UpdateScores(gameID){
           var appController = new DtvGsisDataParser.AppController(); //Or whatever -- you get the idea
           HomeScoreText = appController.GetHomeScore(gameID);
           AwayScoreText = appController.GetAwayScore(gameID);
           OnPropertyChanged("HomeScoreText");
           OnPropertyChanged("AwayScoreText");
        }
        public String HomeScoreText;
        public String AwayScoreText;
    }
