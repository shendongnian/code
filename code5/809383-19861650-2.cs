     private class Test{
            private string s;
            
            public Test(string s)
            {
                this.s = s;
            }
            public static Boolean operator ==(Test c1, Test c2)
            {
                return true;
            }
            public static Boolean operator !=(Test c1, Test c2)
            {
                return false;
            }
        }
        Test x = new Test("Hello");
        Test y = new Test("World");
         MessageBox.Show((x == y).ToString()); // True
