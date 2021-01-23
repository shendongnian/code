    Stopwatch sw = new Stopwatch();
    var request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
    sw.Start();
    using (var response = (HttpWebResponse)request.GetResponse())
    {
         //do something
    }
    sw.Stop();
    Console.Write(string.Format("{0} ms", sw.ElapsedMilliseconds));
    Console.Read();
