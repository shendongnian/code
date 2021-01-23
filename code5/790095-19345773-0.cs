    class EventListener
    {
        Control control; // A valid running winforms control/form created on an STA thread.
        public void ShowDetails(object sender, string message)
        {
            int numero = int.Parse(message);
            control.Invoke(() => ShowDetails(numero))
        }
        private void ShowDetails(int numero)
        {
            Details details = new Details(numero);
            details.Show();
        }
    }
