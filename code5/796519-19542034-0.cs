    private  int GetSum(params TextBox[] arr)
        {
            int sum = 0;
            int temp;
            foreach (TextBox txt in arr)
            {
                int.TryParse(txt.Text,out temp);
                sum += temp;
            }
            return sum;
        }
