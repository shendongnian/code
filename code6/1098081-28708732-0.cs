    static void Main(string[] args)
	{
		String referencePi = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679821480865132823066470938446095505822317253594081284811174502841027019385211055596446229489549303819644288109756659334461284756482337867831652712019091456485669234603486104543266482133936072602491412737245870066063155881748815209209628292540917153643678925903600113305305488204665213841469519415116094330572703657595919530921861173819326117931051185480744623799627495673518857527248912279381830119491298336733624406566430860213949463952247371907021798609437027705392171762931767523846748184676694051320005681271452635608277857713427577896091736371787214684409012249534301465495853710507922796892589235420199561121290219608640344181598136297747713099605187072113499999983729780499510597317328160963185950244594553469083026425223082533446850352619311881710100031378387528865875332083814206171776691473035982534904287554687311595628638823537875937519577818577805321712268066130019278766111959092164201989380952572010654858632788659361533818279682303019520353018529689957736225994138912497217752834791315155748572424541506959508295331168617278558890750983817546374649393192550604009277016711390098488240128583616035637076601047101819429555961989467678374494482553797747268471040475346462080466842590694912933136770289891521047521620569660240580381501935112533824300355876402474964732639141992726042699227967823547816360093417216412199245863150302861829745557067498385054945885869269956909272107975093029553211653449872027559602364806654991198818347977535663698074265425278625518184175746728909777727938000816470600161452491921732172147723501414419735685481613611573525521334757418494684385233239073941433345477624168625189835694855620992192221842725502542568876717904946016534668049886272327917860857843838279679766814541009538837863609506800642251252051173929848960841284886269456042419652850222106611863067442786220391949450471237137869609563643719172874677646575739624138908658326459958133904780275900994657640789512694683983525957098258226205224894077267194782684826014769909026401363944374553050682034962524517493996514314298091906592509372216964615157098583874105978859597729754989301617539284681382686838689427741559918559252459539594310499725246808459872736446958486538367362226260991246080512438843904512441365497627807977156914359977001296160894416948685558484063534220722258284886481584560285060168427394522674676788952521385225499546667278239864565961163548862305774564980355936345681743241125";
        Stopwatch watch = new Stopwatch();
        watch.Restart();
		DecimalX calculatedPi = PiHelper.Calculate(2500);
        watch.Stop();
        Console.WriteLine("Pi with 2500 decimals in " + watch.ElapsedMilliseconds + " ms");
		String hmmmmm = calculatedPi.ToString();
		if (hmmmmm == referencePi)
			throw new SucessException("YES !!!");
	}
	public class DecimalX
	{
		private readonly IntX _integerPart;
		private readonly IntX _scale;
		public DecimalX(IntX integerPart, IntX scale)
		{
			_integerPart = integerPart;
			_scale = scale;
			if (scale.ToString().Any(i => i != '0' && i != '1')) // dirty but works
				throw new Exception("Scale must be 10^X");
		}
		public override string ToString()
		{
			IntX afterPoint = null;
			IntX beforePoint = IntX.DivideModulo(_integerPart, _scale, out afterPoint, DivideMode.AutoNewton);
			return beforePoint.ToString() + "." + afterPoint.ToString();
		}
	}
	public class PiHelper
	{
		public static IntX InverseTan(int denominator, int numberOfDigitsRequired)
		{
			int demonimatorSquared = denominator * denominator;
			int degreeNeeded = GetDegreeOfPrecisionNeeded(demonimatorSquared, numberOfDigitsRequired);
			IntX tenToNumberPowerOfDigitsRequired = GetTenToPowerOfNumberOfDigitsRequired(numberOfDigitsRequired);
			int c = 2 * degreeNeeded + 1;
			IntX s = IntX.Divide(tenToNumberPowerOfDigitsRequired, new IntX(c), DivideMode.AutoNewton); // s = (10^N)/c
			for (int i = 0; i < degreeNeeded; i++)
			{
				c = c - 2;
				var temp1 = IntX.Divide(tenToNumberPowerOfDigitsRequired, new IntX(c), DivideMode.AutoNewton);
				var temp2 = IntX.Divide(s, new IntX(demonimatorSquared), DivideMode.AutoNewton);
				s = temp1 - temp2;
			}
			Console.WriteLine("Number of iterations=" + degreeNeeded);
			// return s/denominator, which is integer part of 10^numberOfDigitsRequired times arctan(1/k)
			return IntX.Divide(s, new IntX(denominator), DivideMode.AutoNewton);
		}
		private static int GetDegreeOfPrecisionNeeded(int demonimatorSquared, int numberOfDigitsRequired)
		{
			//the degree of the Taylor polynomial needed to achieve numberOfDigitsRequired
			//digit accuracy of arctan(1/denominator).
			int degreeNeeded = 0;
			while ((Math.Log(2 * degreeNeeded + 3) + (degreeNeeded + 1) * Math.Log10(demonimatorSquared)) <= numberOfDigitsRequired * Math.Log(10))
			{
				degreeNeeded++;
			}
			return degreeNeeded;
		}
		private static IntX GetTenToPowerOfNumberOfDigitsRequired(int numberOfDigitsRequired)
		{
			var tenToNumberOfDigitsRequired = new IntX(1);
			//  The following loop computes 10^numberOfDigitsRequired
			for (var i = 0; i < numberOfDigitsRequired; i++)
			{
				tenToNumberOfDigitsRequired = IntX.Multiply(tenToNumberOfDigitsRequired, new IntX(10), MultiplyMode.AutoFht);
			}
			return tenToNumberOfDigitsRequired;
		}
		public static DecimalX Calculate(int numberOfDigitsRequired)
		{
			int max = numberOfDigitsRequired + 8; //  To be safe, compute 8 extra digits, to be dropped at end. The 8 is arbitrary
			var a = IntX.Multiply(InverseTan(5, max), new IntX(16), MultiplyMode.AutoFht); //16 x arctan(1/5)
			var b = IntX.Multiply(InverseTan(239, max), new IntX(4), MultiplyMode.AutoFht); //4 x arctan(1/239)
			IntX pi = a - b;
			return new DecimalX(
				IntX.Divide(pi, IntX.Pow(10, (uint)8), DivideMode.AutoNewton)
				, IntX.Pow(10, (uint)numberOfDigitsRequired, MultiplyMode.AutoFht));
		}
	}
	public class SucessException : Exception
	{
		public SucessException(String message)
			: base(message)
		{
		}
	}
