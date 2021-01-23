        public static void NumericEvent(ref string text, ref KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false; //ok
            }
            else
            {
                e.Handled = true; //not ok
            }
        }
