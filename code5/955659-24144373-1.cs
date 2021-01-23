    public class Data
    {
        [MyAttribute(true)]
        public int MyInt { get; set; }
        public void Validate()
        {
            foreach (PropertyInfo pi in typeof (Data).GetProperties())
            {
                var atts = pi.GetCustomAttributes(typeof (MyAttribute), false).FirstOrDefault();
                if (atts != null)
                {
                    var myAtt = atts as MyAttribute;
                    if (myAtt != null)
                    {
                        if (myAtt.MustBePositive)
                        {
                            var propValue = (int)pi.GetValue(this);
                            if (propValue < 0)
                            {
                                Console.WriteLine(@"Invalid");
                            }
                        }
                    }
                }
            }
        }
    }
