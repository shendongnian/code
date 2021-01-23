    public abstract class ClassOne
    {
        public delegate void EventOne();
        public event EventOne fireEventOne;
        public ClassOne()
        { }
        public void Start()
        {
            this.DoFireEventOne();
        }
		protected void DoFireEventOne()
		{
			var feo = fireEventOne;
			if (feo != null)
			{
				feo();
			}
		}
		
        public abstract void Start2();
    }
    public abstract class ClassTwo :ClassOne
    {
        public override void Start2()
        {
            this.DoFireEventOne();
        }
        public abstract void Start3();
    }
    public class ClassThree :ClassTwo
    {
        public override void Start3()
        {
            this.DoFireEventOne();
        }
    }
