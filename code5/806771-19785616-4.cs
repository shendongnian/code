    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Forms;
    namespace ConsoleApplication1 {
      public partial class FormMain : Form {
        private FormProgress m_Form;
        public FormMain() {
          InitializeComponent();
          backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
          backgroundWorker1.ReportProgress(0, "hello");
          Thread.Sleep(2000);
          backgroundWorker1.ReportProgress(20, "world");
          Thread.Sleep(2000);
          backgroundWorker1.ReportProgress(40, "this");
          Thread.Sleep(2000);
          backgroundWorker1.ReportProgress(60, "is");
          Thread.Sleep(2000);
          backgroundWorker1.ReportProgress(80, "simple");
          backgroundWorker1.ReportProgress(100, "end");
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
          if (e.ProgressPercentage == 0 && m_Form == null) {
            m_Form = new FormProgress();
            m_Form.Show();
          }
          if (e.ProgressPercentage == 100 && m_Form != null) {
            m_Form.Close();
            m_Form = null;
            return;
          }
          var message = (string)e.UserState;
          m_Form.UpdateProgress(e.ProgressPercentage, message);
        }
      }
    }
