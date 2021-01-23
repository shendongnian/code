        class A 
        {
            private int i;
            private int j;
            protected int k;
           
            public A()
            {
                i = j = k = 5;
            }
        }
        class B : A
        {
            private int i; //The same variable exist in base class but since it is private I can declare it
            private int j;
            private int k; //Here I get warning, B.k hides inherited member A.k'. Use the new keyword if hiding was intended.	F:\Deepak\deepak\Learning\ClientUdpSocketCommunication\ClientUdpSocketCommunication\Program.cs	210	25	ClientUdpSocketCommunication
 
            private int l;
            private int m;
            private int n;
            public B()
            {
                i= j = this.k = l = m = n = 7; // Here I have used this.k to tell compiler that I want to initialize value of k variable of B.k class
                base.k = 5; //I am assigning and accessing base class variable as it is protected
            }
        }
