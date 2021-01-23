    class AClass
        {
            public int value1 { get; set; }
            public int value2 { get; set; }
            public AClass()
            {
            }
            public AClass(int value1, int value2)
            {
                this.value1 = value1;
                this.value2 = value2;
            }
            public static AClass operator +(AClass obj1, AClass obj2)
            {
                return new AClass(obj1.value1, obj2.value2);
            }
        }
    private void Form1_Load(object sender, EventArgs e)
        {
            AClass obj1 = new AClass();
            obj1.value1 = 14;
            AClass obj2 = new AClass();
            obj2.value2 = 15;
            AClass obj3 = new AClass();
            obj3 = obj1 + obj2;
            label1.Text = obj3.value1.ToString(); // Output 14
            label2.Text = obj3.value2.ToString(); // Output 15
        }
