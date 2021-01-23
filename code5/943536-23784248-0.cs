        public class RequestWWW
        {
            public bool IsDone
            {
                get;
                private set;
            }
            public string Text
            {
                get;
                private set;
            }
            public string Error
            {
                get;
                private set;
            }
            public IEnumerator GetXMLCoroutine(string url)
            {
                WWW www = new WWW(url);
                yield return www;
                IsDone = true;
                Error = www.error;
                Text = www.text;
            }
        }
        public class YourClass: MonoBehaviour
        {
            private RequestWWW wwwcall;
            private void SomeMethod()
            {
                wwwcall = new RequestWWW();
                StartCoroutine(wwwcall.GetXMLCoroutine("http://ya.ru"));
            }
            public void Update()
            {
                if (wwwcall != null && wwwcall.IsDone)
                {
                    Debug.Log(wwwcall.Error);
                    Debug.Log(wwwcall.Text);
                    wwwcall = null;
                }
            }
        }
