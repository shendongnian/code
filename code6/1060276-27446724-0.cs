     public ViewModel()
        {
            ComponentDispatcher.ThreadIdle += ComponentDispatcher_ThreadIdle;
        }
        private void ComponentDispatcher_ThreadIdle(object sender, EventArgs e)
        {
            MessageBox.Show("Idle");
        }
 
