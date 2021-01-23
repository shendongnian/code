    private  double GetSum(params TextBox[] arr)
        {
            double sum = 0;
            double temp;
            foreach (TextBox txt in arr)
            {
                double.TryParse(txt.Text,out temp);
                sum += temp;
            }
            return sum;
        }
