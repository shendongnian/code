    // Really this is just an example of how it could avoid the error you encountered -
    // reality checked only by my cerebral compiler. :)
    public partial class Home : Form
    {
        // instance of the async socket listener to use
        private AsynchronousSocketListener asyncSocketListener; 
        public Home()
        {
            // Initialize the async socket listener, and provide to it a reference to
            // the label it should update.
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
                // // assuming currantRFID is part of the async result ar
                this.targetLabel.Text = ar.currantRFID;
            }
        }
    }
