    List<Dancer> danceFloor = new List<Dancer>();
    danceFloor.Add(new ReservedDancer());
    danceFloor.Add(new SuperFreakDancer ());
	public class Dancer
	{
		public virtual void DoYourDance()
		{
			// do the robot. Everyone knows that one right?
		}
	}
	public class ReservedDancer : Dancer
	{
		public override void DoYourDance()
		{
			// do the waltz
		}
	}
	public class SuperFreakDancer : Dancer
	{
		public override void DoYourDance()
		{
			// breakdance !!!
		}
	}
