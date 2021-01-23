      using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace MSDN15Jan2015_Learning
    {
        /// <summary>
        /// Interaction logic for Window4.xaml
        /// </summary>
        public partial class Window4 : Window
        {
            ObservableCollection<Restaurants> rItems;
            string LetterClicked;
            public Window4()
            {
                InitializeComponent();
                this.Loaded += Window4_Loaded;
                rItems = new ObservableCollection<Restaurants>();
                rItems.Add(new Restaurants() { Name = "Alice Fazoolis", Selected = false });
                rItems.Add(new Restaurants() { Name = "Applebees", Selected = false });
                rItems.Add(new Restaurants() { Name = "Caseys", Selected = false });
                rItems.Add(new Restaurants() { Name = "Cracker Barrell", Selected = false });
                rItems.Add(new Restaurants() { Name = "East Side Marios", Selected = false });
                rItems.Add(new Restaurants() { Name = "Golden Griddle", Selected = false });
                rItems.Add(new Restaurants() { Name = "Harveys", Selected = false });
                rItems.Add(new Restaurants() { Name = "Imperial Buffet", Selected = false });
                rItems.Add(new Restaurants() { Name = "Jack Astors", Selected = false });
                rItems.Add(new Restaurants() { Name = "Kakimono", Selected = false });
                rItems.Add(new Restaurants() { Name = "Kelseys", Selected = false });
                rItems.Add(new Restaurants() { Name = "Little Ceasars", Selected = false });
                rItems.Add(new Restaurants() { Name = "Lonestar", Selected = false });
                rItems.Add(new Restaurants() { Name = "Makimono", Selected = false });
                rItems.Add(new Restaurants() { Name = "Mandarin", Selected = false });
                rItems.Add(new Restaurants() { Name = "McDonalds", Selected = false });
                rItems.Add(new Restaurants() { Name = "Milestones", Selected = false });
                rItems.Add(new Restaurants() { Name = "Montanas", Selected = false });
                rItems.Add(new Restaurants() { Name = "Moxies", Selected = false });
                rItems.Add(new Restaurants() { Name = "Mr. Sub", Selected = false });
                rItems.Add(new Restaurants() { Name = "None", Selected = false });
                rItems.Add(new Restaurants() { Name = "Other (Specify)", Selected = false });
                rItems.Add(new Restaurants() { Name = "Pizza Pizza", Selected = false });
                rItems.Add(new Restaurants() { Name = "Spring Rolls", Selected = false });
                rItems.Add(new Restaurants() { Name = "Subway", Selected = false });
                rItems.Add(new Restaurants() { Name = "St. Louis Bar & Grill", Selected = false });
                rItems.Add(new Restaurants() { Name = "Sunset Grill", Selected = false });
                rItems.Add(new Restaurants() { Name = "Swiss Chalet", Selected = false });
                rItems.Add(new Restaurants() { Name = "Tatemono", Selected = false });
                rItems.Add(new Restaurants() { Name = "The Keg", Selected = false });
                rItems.Add(new Restaurants() { Name = "The Melting Pot", Selected = false });
                rItems.Add(new Restaurants() { Name = "The Outback", Selected = false });
                rItems.Add(new Restaurants() { Name = "Tim Hortons", Selected = false });
                rItems.Add(new Restaurants() { Name = "Wendys", Selected = false });
                rItems.Add(new Restaurants() { Name = "Wimpys Diner", Selected = false });
                rItems.Add(new Restaurants() { Name = "Quiznos", Selected = false });           
            }
            ICollectionView viewCBO;
            ICollectionView viewLST;
            void Window4_Loaded(object sender, RoutedEventArgs e)
            {
                viewCBO = new CollectionViewSource { Source = rItems }.View;
                viewCBO.Filter = SelectedFilter;
                viewLST = new CollectionViewSource { Source = rItems }.View;
                LetterClicked = "-";
                viewLST.Filter = LetterFilter;
                cboSelections.ItemsSource = viewCBO;
                lstAnswers.ItemsSource = viewLST;
            }
            private bool LetterFilter(object item)
            {
                if (((Restaurants)item).Name.ToUpper().StartsWith(LetterClicked))
                    return true;
                else
                    return false;
            }
    
            private bool SelectedFilter(object item)
            {
                if (((Restaurants)item).Selected)
                    return true;
                else
                    return false;
            }
    
            private void btn_Click(object sender, RoutedEventArgs e)
            {   
                LetterClicked =txt.Text;
                viewLST.Filter = null;
                viewLST.Filter = LetterFilter;
                viewLST.Refresh();
            }
    
            private void lstAnswers_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                viewCBO.Refresh();
            }
        }
    
        public class Restaurants:INotifyPropertyChanged
        {
            private string name;
    
            public string Name
            {
                get { return name; }
                set { name = value; OnNotify("Name"); }
            }
    
            private bool selected;
    
            public bool Selected
            {
                get { return selected; }
                set { selected = value; OnNotify("Selected"); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnNotify(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
    
    
    }
