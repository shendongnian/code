    public class baseMenuItem : MenuItem
    {        
        Type windowType;
        public baseMenuItem()
        {
            this.Click += baseMenuItem_Click;
        }
        void baseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(windowType != null){
                window = (Control)Activator.CreateInstance(windowType);
                window.Show();
            }
        }
        public void AssignHandleWindow<T>() where T : baseWindow 
        {
            windowType = typeof(T);
        }
    }
