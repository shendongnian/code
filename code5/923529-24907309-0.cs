    namespace F2FDietPlan
    {
      public partial class DaysOfDietPlan : PhoneApplicationPage
       {
           public MainPage()
           {
              InitializeComponent();
              InterstitialAds();
           }
           private void InterstitialAds()
           {
              interstitialAd = new InterstitialAd("Unit-ID"); // Unit ID is a Unique Key pri
              adRequest = new AdRequest();
              interstitialAd.ReceivedAd += OnAdReceived;
              interstitialAd.LoadAd(adRequest);
            }
           private void OnAdReceived(object sender, AdEventArgs e)
           {
               System.Diagnostics.Debug.WriteLine("Ad received successfully");
               interstitialAd.ShowAd();
           }
        }
    }
