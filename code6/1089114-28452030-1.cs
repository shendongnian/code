    public class MyViewModel : ViewModelBase 
    {
        private StringBuilder sb;
        private string Content 
        {
            return sb.ToString();
        }
        protected Append(string text) {
            sb.Append(text);
            PropertyChanged("Content");
        }
    }
