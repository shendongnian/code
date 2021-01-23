    using System.Threading;
    namespace uc
    {
        class UserControlViewModel
        {
            Timer timer;
    
            ...
            // Desctructor
            ~UserControlViewModel()
            {
                // Stop the timer when the viewmodel gets destroyed
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
    }
