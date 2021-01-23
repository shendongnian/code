    public partial class JoyStickForm : Form
    {
        public JoyStickForm()
        {
            InitializeComponent();
            
            // ...Other initialization code has been stripped...
            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);
            //Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);
            timer1.Interval = 100; 
            timer1.Tick += (s, e) =>
                {
                    joystick.Poll();
                    var lastState = joystick.GetBufferedData().Last(); //only show the last state
                    if (lastState != null)
                    {
                        if (lastState.Offset == JoystickOffset.X)
                        {
                            textBox1.Text = lastState.Value.ToString();
                        }
                    }
                };
            
            //start the timer
            timer1.Enabled = true;
        }
    }
