    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinformsApp2
    {
    	public partial class MainForm : Form
    	{
    		public MainForm()
    		{
    			InitializeComponent();
    		}
    
    		const string leMessage = "<a href='http://example.com'>Go there</a>";
    
    		private async void MainForm_Load(object sender, EventArgs e)
    		{
    			var wb = new WebBrowser();
    
    			TaskCompletionSource<bool> tcs = null;
    			WebBrowserDocumentCompletedEventHandler documentCompletedHandler = (sender2, e2) => tcs.TrySetResult(true);
    
    			for (int i = 0; i < 3; i++)
    			{
    				tcs = new TaskCompletionSource<bool>();
    				wb.DocumentCompleted += documentCompletedHandler;
    				wb.DocumentText = leMessage;
    				await tcs.Task;
    				wb.DocumentCompleted -= documentCompletedHandler;
    
    				HtmlElementCollection elems = wb.Document.GetElementsByTagName("a");
    				foreach (HtmlElement elem in elems)
    				{
    					Debug.Print(elem.OuterHtml);
    				}
    			}
    		}
    	}
    }
 
