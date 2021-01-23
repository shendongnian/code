    public class methodacess
    {
        List<decimal> data = new List<decimal>();
        public void sampleaccess()
        {
            data = dataconversion.dataconvert();
        }
        public void messages()
        {
            MessageBox.Show(data.Count.ToString());
        }
