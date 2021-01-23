    public class MyJson{
        public string token {get;set;}
        public List<Account> answers {get;set;}
        
        public MyJson(){
            answers = new List<Account>();
        }
    }
