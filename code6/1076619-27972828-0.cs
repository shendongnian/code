        public void testmethod(int lower ,int upper , int num)
        {
           while ((lower = num) < upper)
           {
              ++num;
              MessageBox.Show(num.ToString());
           }
        }
