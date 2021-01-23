    class Program {
        static void Main(string[] args) {
            var c = new C();
            c.FillList();
            c.DoSomething();
            Console.ReadKey();
        }
    }
    class C {
        List<A> AList;
        public void FillList() {
            AList = new List<A>();
            var a = new A();
            a.Elements = new List<SuperClass>() { new SubClass(), new SuperClass() };
            AList.Add(a);
            var b = new B();
            b.Elements = new List<SubClass>() { new SubClass(), new SubClass() };
            AList.Add(b);
        }
        public void DoSomething() {
            foreach (var a in AList)
                foreach (var super in a.Elements) { 
                    super.Flag = true;
                    Console.WriteLine(super.GetName());
                }
        }
    }
    class SuperClass {
        public bool Flag;
        public virtual string GetName() { return "super"; } 
    }
    class SubClass : SuperClass {
        public SubClass() { }
        public SubClass(SuperClass x) { }
        public int Number;
        public override string GetName() { return "sub"; } 
    }
    class A {
        public virtual IEnumerable<SuperClass> Elements {
            get{
                return elementList.AsEnumerable();
            }
            set {
                elementList = value.ToList();
            }
        }
        private List<SuperClass> elementList;
    }
    class B : A {
        public override IEnumerable<SuperClass> Elements {
            get {
                return elementList.AsEnumerable();
            }
            set {
                elementList = value.Aggregate(new List<SubClass>(), 
                                    (acc, x) => {
                                        if (x is SubClass) 
                                            acc.Add((SubClass)x);
                                        else 
                                            acc.Add(new SubClass(x)); 
                                        return acc; });
            }
        }
        private List<SubClass> elementList;
    }
