        public class Test
        {
            public static Action loadedTypeAction;
            public void LoadUserControl<T>()
            {
                loadedTypeAction = Execute<T>;
            }
            public void Execute<T>()
            {
                // do stuff
                MessageBox.Show(typeof (T).Name);
            }
            public void DoAction()
            {
                if (loadedTypeAction != null)
                {
                    loadedTypeAction();
                }
            }
        }
