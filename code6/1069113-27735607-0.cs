    class Hubs
    {
        public void Start2(Airport ap)
        {
            if (ap == null) return;
            RadioButton r = ap.rb2;
            Console.WriteLine(r);
            if (r != null && r.Checked)
            {
                Console.WriteLine("Check r");
            }
        }
    }
