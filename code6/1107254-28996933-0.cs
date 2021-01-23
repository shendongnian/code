    public class MainActivity : Activity
    {
        private readonly UdpClient udp = new UdpClient(45000);
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            StartListening();
            Button bt = FindViewById<Button>(Resource.Id.button1);
            bt.Click += delegate { StartListening(); };
        }
 
        public void StartListening()
        {
            this.udp.BeginReceive(Receive, new object());
        }
        public void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 45000);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            DisplayMessage(Encoding.ASCII.GetString(bytes));
            StartListening();
        }
        public void DisplayMessage(string message)
        {
            FindViewById<TextView>(Resource.Id.textView1).Text = message;
        }
    }
