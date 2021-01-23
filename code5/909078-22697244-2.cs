    private void DisplayText(object sender, DataEventArgs e)
    {
         //e.Data is now available
    
         counter2 += counter;
         RxString = counter2.ToString();
         textBox1.AppendText(RxString + "\r\n");
    }
    public class DataEventArgs : EventAgrs
    {
        public byte[] Data {get; set;}
    }
