    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    namespace ExcelAddIn1 {
    public partial class UserControl1 : UserControl {
    
    	public UserControl1() {
    		InitializeComponent();
    	}
    
        private void button1_Click(object sender, EventArgs e)
        {
    		button1.Enabled = false;
    
    		var pf = new ProgressForm();
    		IntPtr handle = new IntPtr(Globals.ThisAddIn.Application.Hwnd);
    		pf.Show(new SimpleWindow { Handle = handle });
    
    		Thread t = new Thread(o => {
    			ExecuteTask((IThreadController) o);
    		});
    		t.IsBackground = true;
    		t.Start(pf);
    
    		pf.FormClosed += delegate {
    			button1.Enabled = true;
    		};
        }
    
        private void ExecuteTask(IThreadController tc)
        {
            for (int i = 1; i <= 100 && !tc.IsStopRequested; i++)
            {
                Thread.Sleep(100);
    			tc.SetProgress(i, 100);
            }
        }
    
    	class SimpleWindow : IWin32Window {
    		public IntPtr Handle { get; set; }
    	}
    }
    
    interface IThreadController {
    	bool IsStopRequested { get; set; }
    	void SetProgress(int value, int max);
    }
    
    public partial class ProgressForm : Form, IThreadController {
    	private ProgressBar _progressBar;
    	private Label _progressLabel;
    
    	public ProgressForm() {
    		//InitializeComponent();
    		this.Width = 300;
    		this.Height = 150;
    		_progressBar = new ProgressBar();
    		_progressBar.Dock = DockStyle.Top;
    		_progressLabel = new Label();
    		_progressLabel.Dock = DockStyle.Bottom;
    		this.Controls.Add(_progressBar);
    		this.Controls.Add(_progressLabel);
    	}
    
    	public void UpdateProgress(int percent) {
    		if (percent >= 100)
    			Close();
    
    		_progressBar.Value = percent;
    		_progressLabel.Text = percent + "%";
    	}
    
    	protected override void OnClosed(EventArgs e) {
    		base.OnClosed(e);
    		IsStopRequested = true;
    
    	}
    
    	public void SetProgress(int value, int max) {
    		int percent = (int) Math.Round(100.0 * value / max);
    
    		if (InvokeRequired) {
    			BeginInvoke((Action) delegate {
    				UpdateProgress(percent);
    			});
    		}
    		else
    			UpdateProgress(percent);
    	}
    
    	public bool IsStopRequested { get; set; }
    }
    
    
    }
