    public interface IMyInterface
    {
      void SetTextBoxText(string text);
    }
    public partial class UC1: UserControl, IMyInterface
    {
       public void SetTextBoxText((string text)
       {
           textBox1.Text=text;
       }
    
    //...
    }
    public partial class UC2: UserControl, IMyInterface
    {
       public void SetTextBoxText((string text)
       {
           textBox1.Text=text;
       }
    
    //...
    }
