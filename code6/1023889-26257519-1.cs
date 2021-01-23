    class Foo
    {
        private EventHandler bar;
        public event EventHandler Bar
        {
            add
            {
                if (bar == null)
                {
                    bar = value;
                }
                else
                {
                    if (!bar.GetInvocationList().Contains(value))
                    {
                        bar += value;
                    }
                }
            }
            remove
            {
                // ...
            }
        }
        public void RaiseBar()
        {
            if (bar != null)
            {
                bar(this, EventArgs.Empty);
            }
        }
    }
