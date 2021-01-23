    public class UserControl1 {
    
       public delegate void DataSortedDelegate(UserControl1 sender, EventArgs e);
    
       public event DataSorted OnDataSorted;
    
       private void button1_Click(object sender, EventArgs e)
       {
          if (OnDataSorted != null)
             OnDataSorted(this, EventArgs.Empty);
          // Replace EventArgs.Empty above with whatever data Form1 needs
       }
