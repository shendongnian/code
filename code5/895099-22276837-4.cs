    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e){
            var data = PrepareYourDataHere;
            OnSaveClicked(data);
            Close();
        }
        public event Action<object> SaveClicked;
        protected virtual void OnSaveClicked(object data){
            var handler = SaveClicked;
            if (handler != null)
                handler(data);
        }
    }
