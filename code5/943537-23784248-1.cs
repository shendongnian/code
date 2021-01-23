        public static class RequestWWW
        {
            public delegate void RequestFinishedHandler(string error, string text);
            public static IEnumerator GetXMLCoroutine(string url, RequestFinishedHandler onFinish)
            {
                WWW www = new WWW(url);
                yield return www;
                if (onFinish != null)
                    onFinish(www.error, www.text);
            }
        }
        public class YourClass: MonoBehaviour
        {
            private void SomeMethod()
            {
                StartCoroutine(RequestWWW.GetXMLCoroutine("http://ya.ru/", RequestFinished));
            }
            private void RequestFinished(string error, string text)
            {
                Debug.Log(error);
                Debug.Log(text);
            }
        }
