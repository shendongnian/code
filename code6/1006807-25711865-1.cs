    public class Form1
    {
    	public void SomeEventHandler(object sender, EventArgs e)
    	{
    		BoxMaker maker = new BoxMaker;
    		TextBox makerMadeTextBox = maker.CreateTextBox();
    		this.Controls.Add(makerMadeTextBox);
    	}
    }
