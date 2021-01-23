    public class PartyClass
    {
        private readonly CancellationToken _cancellationToken;
        public PartyClass(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }
        public void MakeParty()
        {
            while (!_cancellationToken.IsCancellationRequested)
                Console.WriteLine("I'm making a party here");
            Console.WriteLine("The party ended. Please leave now");
        }
    }
    public class MainThread
    {
        public static int Main(String[] args)
        {
            var cancellationSource = new CancellationTokenSource();
            PartyClass party = new PartyClass(cancellationSource.Token);
            Thread partyThread = new Thread(party.MakeParty);
            partyThread.Start();
            System.Threading.Thread.Sleep(5000);
            cancellationSource.Cancel();
            partyThread.Join();
        }
    }
