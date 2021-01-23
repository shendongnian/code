    public partial class Form1 : Form
    {
        List<String> _mList;
        public Form1()
        {
            InitializeComponent();
            // Model -> View Concept
            _mList = new List<string>();
            cls_globalvariables.logList.ListChanged += new ListChangedEventHandler(logList_ListChanged);
            listBox1.DataSource = _mList;
            LOGS.LOG_PRINT("Hello");
            LOGS.LOG_PRINT("Hello");
            LOGS.LOG_PRINT("Hello");
        }
    
        void logList_ListChanged(object sender, ListChangedEventArgs e)
        {
            listBox1.DataSource = null;
            if (cls_globalvariables.logList.Count != 0)
                _mList.Add(cls_globalvariables.logList[cls_globalvariables.logList.Count - 1]);
            listBox1.DataSource = _mList;
        } //
        ....
     }
