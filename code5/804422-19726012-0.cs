    public class MyWorkerClass
    {
        private string _errorMessage = "";
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; }}
        
        public void RunStuff(object sender, DoWorkEventArgs e)
        {
            //... put some code here and fill ErrorMessage whenever you want
        }
    }
