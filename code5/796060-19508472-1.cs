    public partial class Form1 : Form
    {
        private bool running = false;
        public Label OneLabel { get; set; }
        public Label TwoLabel { get; set; }
        public Label ThreeLabel { get; set; }
        private MyMonitor one;
        private Thread vone;
        private Thread two;
        private Thread three; 
        public Form1()
        {
            InitializeComponent();
            
            OneLabel = new Label();
            OneLabel.Text = "Not Smoking";
            OneLabel.Location = new Point(10, 50);
            OneLabel.AutoSize = true;
            this.Controls.Add(OneLabel);
            TwoLabel = new Label();
            TwoLabel.Text = "Not Smoking";
            TwoLabel.Location = new Point(150, 50);
            this.Controls.Add(TwoLabel);
            ThreeLabel = new Label();
            ThreeLabel.Text = "Not Smoking";
            ThreeLabel.Location = new Point(300, 50);
            this.Controls.Add(ThreeLabel);
        }
        private void MainButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                vone.Start();
                two.Start();
                three.Start();
                MainButton.Text = "Stop";
                running = true;
            }
            else
            {
                one.RequestStop();
                MainButton.Text = "Run";
                running = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            one = new MyMonitor(this);
            vone = new Thread(one.Smoker1);
            two = new Thread(one.Smoker2);
            three = new Thread(one.Smoker3);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
            {
                one.RequestStop();
                running = false;
            }
        }
    }
    class MyMonitor
    {
        private int x = 1;
        private Object obj = new Object();
        private Form1 _form;
        bool _finished = false;
        public MyMonitor(Form1 form)
        {
            _form = form;
        }
        public void Smoker1()
        {
            while (!_finished)
            {
                //lock (obj)
                //{
                //    _form.OneLabel.SetPropertyThreadSafe(() => _form.OneLabel.Text, "Smoking");
                //    System.Threading.Thread.Sleep(2000);
                //    _form.OneLabel.SetPropertyThreadSafe(() => _form.OneLabel.Text, "Not Smoking");
                //}
                try
                {
                    Monitor.Enter(obj);
                    try
                    {
                        _form.OneLabel.SetPropertyThreadSafe(() => _form.OneLabel.Text, "Smoking");
                        System.Threading.Thread.Sleep(2000);
                        _form.OneLabel.SetPropertyThreadSafe(() => _form.OneLabel.Text, "Not Smoking");
                    }
                    finally
                    {
                        Monitor.Exit(obj);
                    }
                }
                catch (SynchronizationLockException SyncEx)
                {
                    Console.WriteLine(SyncEx.Message);
                }
            }
        }
        public void Smoker2()
        {
            while (!_finished)
            {
                //lock (obj)
                //{
                //    _form.TwoLabel.SetPropertyThreadSafe(() => _form.TwoLabel.Text, "Smoking");
                //    System.Threading.Thread.Sleep(2000);
                //    _form.TwoLabel.SetPropertyThreadSafe(() => _form.TwoLabel.Text, "Not Smoking");
                //}
                try
                {
                    Monitor.Enter(obj);
                    try
                    {
                        _form.TwoLabel.SetPropertyThreadSafe(() => _form.TwoLabel.Text, "Smoking");
                        System.Threading.Thread.Sleep(2000);
                        _form.TwoLabel.SetPropertyThreadSafe(() => _form.TwoLabel.Text, "Not Smoking");
                    }
                    finally
                    {
                        Monitor.Exit(obj);
                    }
                }
                catch (SynchronizationLockException SyncEx)
                {
                    Console.WriteLine(SyncEx.Message);
                }
            }
        }
        public void Smoker3()
        {
            while (!_finished)
            {
                //lock (obj)
                //{
                //    _form.ThreeLabel.SetPropertyThreadSafe(() => _form.ThreeLabel.Text, "Smoking");
                //    System.Threading.Thread.Sleep(2000);
                //    _form.ThreeLabel.SetPropertyThreadSafe(() => _form.ThreeLabel.Text, "Not Smoking");
                //}
                try
                {
                    Monitor.Enter(obj);
                    try
                    {
                        _form.ThreeLabel.SetPropertyThreadSafe(() => _form.ThreeLabel.Text, "Smoking");
                        System.Threading.Thread.Sleep(2000);
                        _form.ThreeLabel.SetPropertyThreadSafe(() => _form.ThreeLabel.Text, "Not Smoking");
                    }
                    finally
                    {
                        Monitor.Exit(obj);
                    }
                }
                catch (SynchronizationLockException SyncEx)
                {
                    Console.WriteLine(SyncEx.Message);
                }
            }
        }
        public void RequestStop()
        {
            _finished = true;
        }
    }
    //Thread Safe Extension Method
    public static class Extensions
    {
        private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);
        public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }
            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
            }
        }
    }
