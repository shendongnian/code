    class Program
    {
        static void Main(string[] args)
        {
            var π=Math.PI*10000;
            Debug.WriteLine(Display(π));
            // 31,415.926,535,897,931,899
        }
        static string Display(double x)
        {
            int s=Math.Sign(x);
            x=Math.Abs(x);
            StringBuilder text=new StringBuilder();
            var y=Math.Truncate(x);
            text.Append((s*y).ToString("#,#"));
            x-=y;
            if (x>0)
            {
                // 15 decimal places is max reasonable precision
                y=Math.Truncate(x*Math.Pow(10, 15));
                text.Append(".");
                text.Append(y.ToString("#,#").TrimEnd('0'));
            }
            return text.ToString();
        }
    }
