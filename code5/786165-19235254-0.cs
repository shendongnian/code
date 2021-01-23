        public abstract class ActionBase
        {
            protected abstract bool RunRemote();
            protected abstract void RunLocal();
            public void Run()
            {
                if (RunRemote())
                {
                    // ....
                }
                RunLocal();
            }
        }
