    public class Whatever
    {
        public MyClass Mine;
        public Whatever()
        {
            Mine = new MyClass();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
             Mine.WStoneCost = (PriceMethod.StoneCost * AP) / 100;
             //etc
        }
        private void StoneBuy_Click(object sender, EventArgs e)
        {
            //Use it here somehow
        }
    }
