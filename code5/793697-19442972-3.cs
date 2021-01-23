    public class MathOper
		{
			public int Num { get; set; }
			public string Oper { get; set; } //this display the number will be operated.
		}
		public class MathOperCreator
		{
			public readonly string _mathString;//8+2-3
			public MathOperCreator(string mathString)
			{
				this._mathString = mathString.Trim();
			}
			public List<MathOper> Create()
			{
				var lMo = new List<MathOper>();
				int l = this._mathString.Length;//5
				string _mathStringTemp;
				char[] charArr = _mathString.ToCharArray();
				if (charArr[0] != '+' || charArr[0] != '-')
				{
					_mathStringTemp = "+"+_mathString;
				}				else
				{
					_mathStringTemp = _mathString;
				}
				char[] delimitersNumb = new char[] { '+', '-' };
				string[] numbers = _mathStringTemp.Split(delimitersNumb,
						 StringSplitOptions.RemoveEmptyEntries);
				string[] operators = new string[numbers.Length];
				int count = 0;
				foreach (char c in _mathStringTemp)
				{
					if (c == '+' || c == '-')
					{
						operators[count] = c.ToString();			
						count++;
					}
				}
				for(int i=0; i < numbers.Length; i++)
				{
					lMo.Add(new MathOper(){Num = int.Parse(numbers[i]), Oper = operators[i]});
					Console.WriteLine(operators[i]+" "+numbers[i]);
				}
				return lMo;
			}
		}
