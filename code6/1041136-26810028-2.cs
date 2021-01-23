    public partial class ViewPurchase : Form
    {
        readonly IDataRetriever _dataRetriever;
        public ViewPurchase(IDataRetriever dataRetriever, string aa)
        {
            _dataRetriever = dataRetriever;
            label2.Text = aa;
        }
    }
