    using System;
    namespace WpfApplication1
    {
        public class MyViewModel
        {
            private MyModel myModel;
            public MyViewModel()
            {
                this.myModel = new MyModel() { Int1 = 1, Int2 = 12, Text1 = "toto" };
            }
            public String MyText
            {
                get { return this.myModel.Text1; }
                set { this.myModel.Text1 = value; }
            }
            public Int32 MyInt1
            {
                get { return this.myModel.Int1; }
                set { this.myModel.Int1 = value; }
            }
            public Int32 MyInt2
            {
                get { return this.myModel.Int2; }
                set { this.myModel.Int2 = value; }
            }
        }
    }
