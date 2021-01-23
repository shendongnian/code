    public static class Caller {
        public static event EventHandler Updating;
        public static Update() {
            var handler = Updating;
            if (handler ¡= null) handler(null, EventArgs.Empty);
        }
     }
    public abstract class Base {
        protected Base() {
            Caller.Updating += Caller_Updating;
        }
        void Caller_Updating(object sender, EventArgs e) {
            Update();
        }
        protected abstract Update();
     }
