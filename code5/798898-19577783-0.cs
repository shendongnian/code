    using Word = Microsoft.Office.Interop.Word;
    
    
    namespace WindowsFormsApplication1
    {
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load_1(object sender, EventArgs e)
		{
		}
		public void ShowExternalReference(string externalRef, bool waitForCompletion)
		{
			if (externalRef.Length > 0)
			{
				var pInfo = new ProcessStartInfo { FileName = externalRef };
				bool isrunning = false;
				Process [] pList = Process.GetProcesses();
				foreach(Process x in pList)
				{
					if( x.ProcessName.Contains("WINWORD"))
					{
						isrunning = true;
						Word.Application myWordApp =
							  System.Runtime.InteropServices.Marshal.GetActiveObject(
							  "Word.Application") as Word.Application;
						if(myWordApp.ActiveDocument.FullName.Contains(externalRef))
							// do something
							myWordApp.ActiveDocument.Content.Text = " already open";
					}
				}
				if(!isrunning)
				{
					// Start the process.
					Process p = Process.Start(pInfo);
					if (waitForCompletion)
					{
						// Wait for the window to finish loading.
						p.WaitForInputIdle();
						// Wait for the process to end.
						p.WaitForExit();
					}
				}
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			string myWordFile = @"C:\Temp\test.docx";
			ShowExternalReference(myWordFile, true);
		}
		private void listView1_ItemChecked(object sender, ItemCheckEventArgs e)
		{
			listView1.Items[e.Index].Group = listView1.Groups[e.NewValue == CheckState.Checked ? 0 : 1];
		}
