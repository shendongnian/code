       DateTime Tthen = DateTime.Now;
       do
       {
            //Your code or nothing...
            Application.DoEvents();
       }
       while (Tthen.AddSeconds(15) > DateTime.Now);
