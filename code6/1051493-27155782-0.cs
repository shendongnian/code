        public static string test()
        {
            double dub = 5432;
            string dubTxt = dub.ToString();
            string text = "0.";
            string test = string.Concat(text + dubTxt);
            if (1 == 1)
            {
               
               MessageBox.Show(test);
               return test;
            }
        }
