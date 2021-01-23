        public static void SetCausesValidation(Control.ControlCollection ctls, bool enable) {
            foreach (Control ctl in ctls) {
                ctl.CausesValidation = enable;
                SetCausesValidation(ctl.Controls, enable);
            }
        }
