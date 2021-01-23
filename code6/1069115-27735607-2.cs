    class Hubs
    {
        public void Start2(object airport)
        {
            var ap = airport as Airport;
            if (ap == null) return;
            RadioButton r = ap.rb2;
            Console.WriteLine(r);
            if (r != null && r.Checked)
            {
                Console.WriteLine("Check r");
            }
        }
    }
