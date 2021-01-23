        public class TransactionViewModel
        {
            public ArticleModel CurrentArticleModel { get; set; }
            public String Name 
            {
                get { return CurrentArticleModel.Name; }
                
                set 
                {
                    CurrentArticleModel.Name = value;
                    NotifyPropertyChange("Name");
                }
        }
