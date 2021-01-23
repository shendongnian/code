    public class MyClass 
    {
        protected List<Keys> vowelz = new List<Keys>();
        
        public void vowelbutton_Click(object sender, EventArgs e)
        {
            Random randomizer = new Random();
            vowelz.Add(Keys.A);
            vowelz.Add(Keys.A);
            vowelz.Add(Keys.A);
            vowelz.Add(Keys.B);
            var indexz1 = randomizer.Next(0, vowelz.Count);
            var keyz1 = vowelz[indexz1];
            listBox1.Items.Add(vowelz[indexz1]);
            vowelz.RemoveAt(indexz1);
        }   
    }
