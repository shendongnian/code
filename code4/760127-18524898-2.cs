    public partial class Form1 : Form {
      public Form1() {
        InitializeComponent();
        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
      }
      void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e) {
        if (e.Category == UserPreferenceCategory.Locale) { 
          CultureInfo.CurrentCulture.ClearCachedData(); 
        }
      }
      private void button1_Click(object sender, EventArgs e) {
        MessageBox.Show(CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol); 
      }
      private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
        SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
      }
    }
