    public class Proxy : INPC
    {
        public String Url
		{
			get
			{
				return url;
			}
			set
			{
				if (url== value) {
					return;
				}
				url= value;
				RaisePropertyChanged("Url");
			}
		}
        private string url;
        public String Port
		{
			get
			{
				return port;
			}
			set
			{
				if (port== value) {
					return;
				}
				port= value;
				RaisePropertyChanged("Port");
			}
		}
        private string port;
    }
