        public void addqty()
        {
            int a, b;
            if (!int.TryParse(val1.Text, out a) || int.TryParse(val2.Text, out b))
                result.Text = "Can't convert variable a or variable b";
            else
                result.Text = (a + b).ToString();                        
        }
