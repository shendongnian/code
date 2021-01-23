    // Make sure to enable asynchronous request processing:
    // <%@ Page Async="true" ... %>
    public partial class AsyncTest : System.Web.UI.Page
    {
        private String _taskprogress;
    
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ReadFileAsync));
        }
    
        public async Task ReadFileAsync()
        {
            try
            {
                string Filename = @"D:\Material.txt";
                int filelength = TotalLines(Filename); //just reads the lines of the file
    
                ProgressBar1.Maximum = filelength;
    
                using (StreamReader reader = new StreamReader(Filename))
                {
                    string line;
                    int actualfileline = 1;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string test = line;
                        ProgressBar1.Value = actualfileline;
                        actualfileline++;
                        //UpdatePanel1.Update(); <- Doesnt work
                        System.Threading.Thread.Sleep(5);
                    }
                }
            }
            catch (Exception ex)
            {
                string exm = ex.Message.ToString();
            }
        }
    }
