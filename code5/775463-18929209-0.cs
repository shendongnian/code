    //Btw should be PmScreen or something else that follows naming conventions
    public partial class pm_screen : Form  
    {
        Form1 parentForm;
        public pm_screen(Form1 parentForm)
        {
            this.parentForm = parentForm;
        }
        //Write GUI code for the class here...
        public void acceptMessageFromParent(string message)
        {
            //Do stuff with string message
        }
        private void sendMessageToParent(string message)
        {
            parentForm.acceptMessageFromPrivate(message);
        }
    }
    public partial class Form1 : Form
    {
        private void createPrivateMessageForm()
        {
            pm_screen privateScreen = new pm_screen(this);
            //You might want to store privateScreen in a List here, so you can
            //have several pm_screen instances per Form1
        }
        private void sendMessageToPrivate(pm_screen privateScreen, string message)
        {
            privateScreen.acceptMessageFromParent(message);
        }
        public void acceptMessageFromPrivate(string message)
        {
            //Do stuff with string message
        }
    }
