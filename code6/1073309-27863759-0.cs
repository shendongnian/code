    public partial class AdductionAbductionFlexionView : UserControl
    {
        Channel channel;
        Hub hub;
        public AdductionAbductionFlexionView()
        {
            InitializeComponent();
            // create a hub that will manage Myo devices for us
            channel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create()));
            hub = Hub.Create(channel);
            {
                 //set a bpoint here, gets triggered
                // listen for when the Myo connects
                hub.MyoConnected += (sender, e) =>
                {
                     //set a bpoint here, doesn't get triggered
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        statusTbx.Text = "Myo has connected! " + e.Myo.Handle;
                        //Console.WriteLine("Myo {0} has connected!", e.Myo.Handle);
                        e.Myo.Vibrate(VibrationType.Short);
                    }));
                };
                // listen for when the Myo disconnects
                hub.MyoDisconnected += (sender, e) =>
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        statusTbx.Text = "Myo has disconnected!";
                        //Console.WriteLine("Oh no! It looks like {0} arm Myo has disconnected!", e.Myo.Arm);
                        e.Myo.Vibrate(VibrationType.Medium);
                    }));
                };
                // start listening for Myo data
                channel.StartListening();
            }
        }
    }
