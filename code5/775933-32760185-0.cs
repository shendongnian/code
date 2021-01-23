	public static void Main()
	{
		string term1="15245142151235123512352362362352351236";
		string term2="1522135123612646436143613461344";
		StringBuilder sum=new StringBuilder();
		int n1=term1.Length;
		int n2=term2.Length;
		int carry=0;
		int n=(n1>n2)?n1:n2;
		if(n1>n2)
		term2=term2.PadLeft(n1,'0');
		else
		term1=term1.PadLeft(n2,'0');
		for(int i=n-1;i>=0;i--)
		{
			int value=(carry+term1[i]-48+term2[i]-48)%10;
			sum.Append(value);
			carry=(carry+term1[i]-48+term2[i]-48)/10;
		}
		char[] c=sum.ToString().ToCharArray();
		Array.Reverse(c);
		Console.WriteLine(c);
	}
}
