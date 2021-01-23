    static void Main(string[] args) {
        Stopwatch st = new Stopwatch();
        while (true) {
            st.Restart();
            System.Threading.Thread.Sleep(1);
            st.Stop();
            Console.Write("{0} ", st.Elapsed.Ticks / 10000.0);
            System.Threading.Thread.Sleep(200);
        }
    }
