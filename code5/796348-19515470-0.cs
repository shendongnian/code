		public static double DiscreteSum(Func<double, double> F1, double t1, double t2)
		{
			double s = 0;
			for(long i = (t1<t2?t1:t2); i < (t1<t2?t2:t1); i++)
			{
				s += F1(i);
			}
			return s;
		}
