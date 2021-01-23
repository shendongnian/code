    public class Foo {
        private int m_bar;
        public int Bar {
            get { return m_bar; }
            set {
                m_bar = value;
                OnChanged();
            }
        }
        public event EventHandler Changed;
        protected virtual void OnChanged() {
            var evt = Changed;
            if (evt != null)
                evt(this, EventArgs.Empty);
        }
    }
