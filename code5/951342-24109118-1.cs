    using Outlook = Microsoft.Office.Interop.Outlook;
    .
    .
    .
    public partial class MyWinForm : Form
    {
        private Outlook.Application m_OutlookApp;
        public MyWinForm(Outlook.Application OutlookApp)
        {
            m_OutlookApp = OutlookApp;
            InitializeComponent();
        }
