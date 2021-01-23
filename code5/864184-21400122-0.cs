    public partial class Home : Form
     {
         public class AsynchronousSocketListener
         {
             private Label myLabel;
             public AsynchronousSocketListener(Label lbl)
             {
                myLabel = lbl;
             }
             public void ReadCallback(IAsyncResult ar)
             {
               //Here I want to Update a labels text this waw :
               myLabel.Text = currantRFID;
             }
         }
     }
