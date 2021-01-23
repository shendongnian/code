    public delegate void GoogleServerResponse(string result);
    public class PassEvent
    {
        public static event GoogleServerResponse OnGoogleServerResponse;
        private void Start()
        {
            print("going to google...");
            StartCoroutine(GetStringFromServer("http://google.com", OnGoogleServerResponse));
        }
        private void print(string p)
        {
            
        }
        private void StartCoroutine(IEnumerator enumerator)
        {
        }
        private IEnumerator GetStringFromServer(string url, GoogleServerResponse myEvent)
        {
            Uri www = new Uri(url);
            yield return www;
            if (myEvent != null)
            {
                myEvent(www.text);
            }
        }
    }
