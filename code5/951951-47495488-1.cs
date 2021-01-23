     public SelftestAdv2(int x)
            {
                B b1 = new B(); b1.v = 3;
                B b2 = new B(); b2.v = 4;
    
                B b3 = new B(); b3.v = 5;
                B b4 = new B(); b4.v = 6;
    
                A a1 = new A();a1.id = 1;
                a1.b.Add(b1);
                a1.b.Add(b2);
    
                A a2 = new A();a2.id = 2;
                a2.b.Add(b3);
                a2.b.Add(b4);
    
                List<A> listA = new List<A>();
    
                listA.Add(a1);
                listA.Add(a2);
    
                XmlSerializer xs = new XmlSerializer(typeof(List<A>), new XmlRootAttribute("FieldConfiguration"));
    
                using (var streamReader = new StreamWriter("fff.xml"))
                {
    
                    xs.Serialize(streamReader,listA);
    
                }
    
    
            }
    `
