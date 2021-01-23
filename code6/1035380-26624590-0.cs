    class Test 
    { 
        Font Font {set; get;}  
        public Test()
        {
            using (var font = new Font("Arial", 16, FontStyle.Bold))
            {
                // do something with font here
            } // font is automatically disposed when going out of scope
      
        }
    }
