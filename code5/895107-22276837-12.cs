    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }
        // create an event of Action<T> which T is your data-type. e.g. in this example I use an object. 
        public event Action<object> SaveClicked;
        // create an event invocator, to invoke event whenever you want
        protected virtual void OnSaveClicked(object data){
            var handler = SaveClicked;
            if (handler != null)
                handler(data);
        }
        private void button1_Click(object sender, EventArgs e){
            // prepare your data here, -object, or string, or int, or whatever it is
            var data = PrepareYourDataHere;
            // invoke the event
            OnSaveClicked(data);
            Close();
        }
    }
