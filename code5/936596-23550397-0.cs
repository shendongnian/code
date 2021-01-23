    public class MyClass
    {
        public int Do(string str)
        {
            try
            {
                int num = int.Parse(str);
                return num;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
