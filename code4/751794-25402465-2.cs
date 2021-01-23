    System.Threading.Thread tre = new System.Threading.Thread(new ThreadStart(MyFunction));
    tre.Start();
    System.Threading.Thread.Sleep(10000);
    if (tre.IsAlive)
    tre.Abort();
    //The you have your function
    void MyFunction()
    {
    //Do process
    }
