	public class Form1:Form{
		public void Say(string Text)
		{
			lalSay.Text = Text;
		}
	}
	public class AnotherClass{
		public void ConsumingMethod()
		{
			var say = new Form1();
			say.Say("Darn i dont have" + ItemCost + "Bits.");
		}	
	}
