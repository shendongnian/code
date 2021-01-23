        public new event EventHandler Click {
            add {
                subscribeToEvent(this, value);
            }
            remove {
                unsubscribeFromEvent(this, value);
            }
        }
        private void subscribeToEvent(Control control, EventHandler eventHandler) {
            control.Click += eventHandler;
            foreach (Control child in control.Controls) {
                subscribeToEvent(child, eventHandler);
            }
        }
        private void unsubscribeFromEvent(Control control, EventHandler eventHandler) {
            control.Click -= eventHandler;
            foreach (Control child in control.Controls) {
                subscribeToEvent(child, eventHandler);
            }
        }
