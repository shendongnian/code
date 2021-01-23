    public partial class Home : Form
    {
        private AsynchronousSocketListener asyncSocketListener; // instance of the async socket listener to use
        public Home()
        {
            // Initialize the async socket listener, and provide to it a reference to the label it should update.
            asyncSocketListener = new AsynchronousSocketListener(label1);
        }
        
        public class AsynchronousSocketListener
        {
            Label targetLabel;
            
            public AsynchronousSocketListener(Label targetLabel)
            {
                this.targetLabel = targetLabel;
            }
            
            public void ReadCallback(IAsyncResult ar)
            {
                this.targetLabel.Text = ar.currantRFID; // assuming currantRFID is part of the async result ar
            }
        }
    }
