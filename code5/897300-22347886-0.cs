    public static class FormExt {
        public static void Execute(this Control c, Action a) {
            if (c.InvokeRequired) {
                c.Invoke(a);
            } else {
                a();
            }
        }
    }
