    private void Form1_Load(object sender, EventArgs e)
    {
        List<ProcessInfoItem> piis = GetAllProcessInfos();
        listBox1.DisplayMember = "Name";
        listBox1.ValueMember = "Id";
        listBox1.DataSource = piis;
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Do whatever you want here
    }
    private List<ProcessInfoItem> GetAllProcessInfos()
    {
        List<ProcessInfoItem> result = new List<ProcessInfoItem>();
        Process currentProcess = Process.GetCurrentProcess();
        Process[] localAll = Process.GetProcesses();
        foreach (Process p in localAll)
        {
            try
            {
                if (p.Id != 4 && p.Id != 0 && p.MainModule != null)
                {
                    ProcessInfoItem pii = new ProcessInfoItem(p.Id, p.MainModule.ModuleName, p.MainModule.FileName);
                    result.Add(pii);
                }
            }
            catch (Win32Exception)
            {   // Omit "Access is denied" Exception
            }
            catch (Exception)
            {
                throw;
            }
        }
        return result;
    }
    public class ProcessInfoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public ProcessInfoItem()
        { }
        public ProcessInfoItem(int id, string name, string filename)
        {
            this.Id = id;
            this.Name = name;
            this.FileName = filename;
        }
    }
