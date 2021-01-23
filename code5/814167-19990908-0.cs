	public class MySayClass{
		public void Say(string Text)
		{
			lalSay.Text = Text;
		}
	}
	public class AnotherClass{
		public void ConsumingMethod()
		{
			var say = new MySayClass();
			say.Say("Darn i dont have" + ItemCost + "Bits.");
		}	
	}
