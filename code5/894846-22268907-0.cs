    public class MyForm : Form
    {
        public void SomeMethod()
        {
            try
            {
                var sc = new ServiceClass();
                sc.ReverseGeocodePoint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
