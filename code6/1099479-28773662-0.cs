    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;
    
    namespace DynamicDataBinding.Pages
    {
        /// <summary>
        /// Interaction logic for Page1.xaml
        /// </summary>
        public partial class Page1 : UserControl
        {
            public Page1()
            {
                InitializeComponent();
                foreach (Language lang in Global.availableLanguages) 
                {
                    cbox_lang.Items.Add(lang.Name);
                }
                cbox_lang.SelectedItem = Global.currentLanguage.Name;
                this.DataContext = Global.FrameWork;
            }
    
            private void cbox_lang_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (cbox_lang.SelectedItem.ToString() != Global.currentLanguage.Name)
                {
                    string selectedLanguage = cbox_lang.SelectedItem.ToString();
                    Global.currentLanguage = Global.availableLanguages.Find(lang => lang.Name == selectedLanguage);
                    Global.currentLanguage.set();
                    DataContext = null;
                    DataContext = Global.FrameWork;
                }
            }
        }
    
        public class Global
        {
            public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
            public static List<Language> availableLanguages = new List<Language>();
            public static Language currentLanguage;
            public static Translation FrameWork = new Translation();
        }
    
        public class Language
        {
    
            public string Name;
            public Language(string name)
            {
                this.Name = name;
            }
    
            public void set()
            {
                Global.dictionary.Clear();
                if (Global.currentLanguage.Name == "Language 1")
                {
                    Global.FrameWork.home_text_1 = "Content For Home in Language 1";
                    Global.FrameWork.page1_text_1 = "Content For Home in Language 1";
    
                }
                else if (Global.currentLanguage.Name == "Language 2")
                {
                    Global.FrameWork.home_text_1 = "Different Content For Home in Language 2";
                    Global.FrameWork.page1_text_1 = "Different Content For Home in Language 2";
                }
            }
        }
    
        public class Translation : INotifyPropertyChanged 
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            private string _home_text_1;
            private string _page1_text_1;
    
            public string home_text_1 { get {return _home_text_1;} set { _home_text_1 = value; OnPropertyChanged("home_text_1"); }}
            public string page1_text_1 { get {return _page1_text_1;} set { _page1_text_1 = value; OnPropertyChanged("page1_text_1");}}
        }
    }
