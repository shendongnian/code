    const int threads = 30000;
    var certificateLists = new List<X509Certificate2>();
    var taskList = new List<Task>();
    int totalCall = 0;
    for (int i = 0; i < threads; i++)
    {
        taskList.Add(Task.Factory.StartNew(() =>
        {
            certificateLists.Add(CertificateHelper.ClientPersonalCertificate);
            Interlocked.Increment(ref totalCall);
        }));
    }
    Task.WaitAll(taskList.ToArray());
    X509Certificate2 x509Certificate2Last = null;
    Assert.AreEqual(threads, totalCall);
    Assert.AreEqual(threads, certificateLists.Count);
