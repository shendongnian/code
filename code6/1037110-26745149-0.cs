    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using Windows.ApplicationModel;
    using Windows.Storage;
    using Windows.UI.Core;
    using TouristAppV3.Annotations;
    using TouristAppV3.Classes;
    using TouristAppV3.Enums;
    using TouristAppV3.Model;
    
    namespace TouristAppV3.ViewModel
    {
        class SecondPageViewModel : INotifyPropertyChanged
        {
            #region Fields
            private IEnumerable<XElement> xml;
            private string _selectedCategory = MainPageViewModel.SelectedCategory;
            private string _xmlElementOfInterrest = "type";
            private ObservableCollection<GenericModel> _places;
    
            #endregion
    
            #region Constructor
            public SecondPageViewModel()
            {
                LoadXML();
                Places = new ObservableCollection<GenericModel>();
                PopulatePlaces();
            }
    
    
            #endregion
    
            #region Methods
            /// <summary>
            /// Loads xml for _selectedCategory
            /// </summary>
            private void LoadXML()
            {
                XMLContainer xmlContainer = XMLContainer.GetInstance();
                switch (_selectedCategory)
                {
                    case "Bars":
                        xml = xmlContainer.ReturnXMLFrom(Categories.Bars);
                        break;
                    case "Hotels":
                        xml = xmlContainer.ReturnXMLFrom(Categories.Hotels);
                        break;
                    case "Restaurants":
                        xml = xmlContainer.ReturnXMLFrom(Categories.Restaurants);
                        break;
                    case "Museums":
                        xml = xmlContainer.ReturnXMLFrom(Categories.Museums);
                        break;
                    case "Festivals":
                        xml = xmlContainer.ReturnXMLFrom(Categories.Festivals);
                        break;
                }
                
            }
    
            private void PopulatePlaces()
            {
                if (_selectedCategory == Categories.Bars.ToString() ||
                    _selectedCategory == Categories.Hotels.ToString() ||
                    _selectedCategory == Categories.Museums.ToString() ||
                    _selectedCategory == Categories.Restaurants.ToString())
                {
                    if (_selectedCategory == Categories.Hotels.ToString())
                    {
                        _xmlElementOfInterrest = "quality";
                    }
                    if (_selectedCategory == Categories.Museums.ToString())
                    {
                        _xmlElementOfInterrest = "subtitle";
                    }
                }
                try
                {
                    foreach (XElement place in xml)
                    {
                        string name = place.Attribute("name").Value;
                        string subtitle = place.Element(_xmlElementOfInterrest).Value;
                        string imagePath = place.Element("imageURL").Value;
                        Places.Add(new GenericModel(name, subtitle, _selectedCategory, imagePath));
                    }
                }
                catch (Exception)
                {
                }
            }
    
            #endregion
    
            #region Properties
    
            public string PageName
            {
                get { return _selectedCategory; }
                private set { _selectedCategory = value; }
            }
    
            public ObservableCollection<GenericModel> Places
            {
                get { return _places; }
                set { _places = value; }
            }
    
            #endregion
            
            #region OnPropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
