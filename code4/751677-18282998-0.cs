    public void TestStuff() 
    {
        string testing = "test";
        webBrowser2.DocumentCompleted += (s, e) =>
            {
                MessageBox.Show(testing);
            };
        webBrowser2.Navigate("http://google.com");
    }
