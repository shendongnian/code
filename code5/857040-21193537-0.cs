    struct Complex
    {
        float re, im;
        public static Complex Parse(string text)
        {
            text=text.Replace(" ", string.Empty); //trim spaces
            float re=0, im=0;
            int i_index=text.IndexOf('i');
            if(i_index>=0) //if no 'i' is present process as real only
            {
                text=text.Substring(0, i_index); //ignore all after i
                int i=0;
                //find start of digits
                while(i<text.Length&&(text[i]=='+'||text[i]=='-'))
                {
                    i++;
                }
                //find end of digits
                while(i<text.Length&&(char.IsNumber(text, i)|| text.Substring(i).StartsWith(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)))
                {
                    i++;
                }
                // parse real (first) portion
                float.TryParse(text.Substring(0, i), out re);
                // had 'i' but no numbers
                if(text.Length==0)
                {
                    im=1;
                }
                else
                {
                    //parse remaining value as imaginary
                    text=text.Substring(i+1);
                    float.TryParse(text, out im);
                }
            }
            else
            {
                float.TryParse(text, out re);
            }
            // Build complex number
            return new Complex() { re=re, im=im };
        }
        public override string ToString()
        {
            return string.Format("({0},{1})", re, im);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test=new[] { "1", "i", "5+2i", "-5+2i", "+5-2i", "0.23+0.72i" };
            for(int i=0; i<test.Length; i++)
            {
                Debug.Print( Complex.Parse(test[i]).ToString() );
            }
        }
    }
