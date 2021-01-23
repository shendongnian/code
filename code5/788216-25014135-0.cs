	void Main() {
		MyImmutable o = new MyImmutable(new MyMutable { Message = "hello!", A = 2});
		Console.WriteLine(o.Value.A);//prints 3
		o.Value.IncrementA();        //compiles & runs, but mutates a copy
		Console.WriteLine(o.Value.A);//prints 3 (prints 4 when Value isn't readonly)
		//o.Value.B = 42;            //this would cause a compiler error.
		//Consume(ref o.Value.B);    //this also causes a compiler error.
	}
	struct MyMutable {
		public string Message;
		public int A, B, C, D;
		//avoid mutating members such as the following:
		public void IncrementA() { A++; } //safe, valid, but really confusing...
	}
	class MyImmutable{
		public readonly MyMutable Value;
		public MyImmutable(MyMutable val) {
			this.Value=val;
			Value.IncrementA();
		}
	}
	void Consume(ref int variable){}
