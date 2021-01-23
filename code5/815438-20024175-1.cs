     public partial class Form1 : Form
      {
         Thread ab1;   
         public Form1()
        {
             InitializeComponent();
            Thread ab1 = new Thread(new ThreadStart(ThreadProc));
            ab1.SetApartmentState(ApartmentState.STA);
            ab1.Start();
            bool isAlive = true ;
            TimerCallback tmrCallBack = new TimerCallback(CheckStatusThreadHealth);  
            System.Threading.Timer tmr = new System.Threading.Timer(tmrCallBack,isAlive,2000,2000);
         }
         public void CheckStatusThreadHealth(object isAlive)
         {
             isAlive = ab1.IsAlive ;  
         }
         private void ThreadProc()
         {
             Form frm = new Form1();
            frm.ShowDialog();
         }
