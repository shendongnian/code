    class TestClass
    {
        private string[] labels;
       
        public TestClass(int sizeOfArray size)
        {
            labels = new string[size];
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Random randomNum = new Random();
            int random1 = randomNum.Next(1, 99);
            String labelText = Convert.ToString(random1);
            label10.Text = labelText;
            labels[determineFreeIndex] = labelText;
        }
    }
