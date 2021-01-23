    public class Window1 : Window
    {
        private readonly StateMachine _stateMachine;
        private readonly MyBusinessObject _businessObject;
        public Window1(MyBusinessObject businessObject, StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _businessObject = businessObject;
        }
        public void on_Button_Next_Click(object sender, EventArgs args)
        {
            // look ma, no logic ...
            var nextWindow = _stateMachine.Next(_businessObject);
            if (nextWindow != null)
                nextWindow.Show();
            this.Close();
        }
    }
