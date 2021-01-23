            var myC1 = new Class1 { MyVar1 = 10 };
            var myC2 = new Class2 { MyVar2 = 15 };
            Console.WriteLine(myC2.MyVar1);
            var myC3 = new Class1 { MyVar1 = 11 };
            Console.WriteLine(myC2.MyVar1);
            Console.WriteLine(myC1.MyVar1);
