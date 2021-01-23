       public void start_new_page()
       {
            Dispatcher.Invoke(
                  (Action)delegate()
            {
                 Form1 f = new Form1();
                 Application.Run(f);
            }, System.Windows.Threading.DispatcherPriority.Normal);
        }
