	public void Main()
	{
		AbstractClass X = new Foo();
		Test2 test2 = new Test2(X);
		X = new Bar(); 
		// change test2.Y
		test2.Y = X;
		if (X == test2.Y)
			MessageBox.Show("They are equal! Success!!");
		else
			MessageBox.Show("Not equal :( ");
	}
