    public class MaintenanceTask
    {
        private CancellationTokenSource m_CancellationTokenSource;
        private Task m_FirstTask;
        private Task m_LastTask;
        public MaintenanceTask()
        {
            m_CancellationTokenSource = new CancellationTokenSource();
        }
        public void AddTaskIdent(TaskIdentBase ident)
        {
            Task newTask = ident.Create(m_CancellationTokenSource.Token);
            
            if (m_FirstTask == null)
            {
                m_FirstTask = newTask;
                m_LastTask = m_FirstTask;
            }
            else
            {                
                m_LastTask.ContinueWith(prev => newTask.Start());
                m_LastTask = newTask;
            }
        }
        public void Run()
        {
            if (m_FirstTask != null)
                m_FirstTask.Start();
        }
    }
