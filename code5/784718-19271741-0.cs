    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using DatabaseLayer;
    using System.Data;
    
    namespace WPFnMVVM.ViewModel 
    {
        public class ContactsViewModel : WPFnMVVM.Common.VMBase
        {
            #region Variables
            private int _Id;
            private string _First_Name;
            private string _Last_Name;
            private DateTime _DOB;
            private clstbl_Contacts _Contacts;
            public WPFnMVVM.Common.RelayCommand _addCommand;
            public ObservableCollection<clstbl_Contacts> _ContactsList;
            #endregion
    
            #region Contructor
            public ContactsViewModel()
            {
                LoadContacts();
            }      
            #endregion
    
            #region Public Properties
            public int Id
            {
                get { return _Id; }
                set { _Id = value; OnPropertyChanged("Id"); }
            }
            public string First_Name
            {
                get { return _First_Name; }
                set { _First_Name = value;
                
                    OnPropertyChanged("First_Name"); }
            }
            public string Last_Name
            {
                get { return _Last_Name; }
                set { _Last_Name = value; OnPropertyChanged("Last_Name"); }
            }
            public DateTime DOB
            {
                get { return _DOB; }
                set { _DOB = value; OnPropertyChanged("DOB"); }
            }
            public clstbl_Contacts Contacts
            {
                get { return _Contacts; }
                set
                {
                    _Contacts = value;
    
                    OnPropertyChanged("Contacts");
                    GetValuesFromModel();
                }
    
    
            }
            public ObservableCollection<clstbl_Contacts> ContactsList
            {
                get { return _ContactsList; }
                set
                {
                    _ContactsList = value;
                    OnPropertyChanged("ContactsList");
                }
            }     
            #endregion
    
            #region Methods
            private void LoadContacts()
            {
    
                clstbl_Contacts objContact = new clstbl_Contacts(WPFnMVVM.Common.clsSettings.ConStr);
                DataTable dt = objContact.Select();
                _ContactsList = new ObservableCollection<clstbl_Contacts>();
    
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _ContactsList.Add(new clstbl_Contacts { Id = Convert.ToInt16(dt.Rows[i]["ID"].ToString())
                                                            ,First_Name = dt.Rows[i]["First_Name"].ToString(),
                                                            Last_Name = dt.Rows[i]["Last_Name"].ToString(),
                                                            DOB = Convert.ToDateTime(dt.Rows[i]["DOB"].ToString())
                    });
                }
    
            }
            private void AddContacts()
            {
                clstbl_Contacts objContacts = new clstbl_Contacts(WPFnMVVM.Common.clsSettings.ConStr);
                objContacts.First_Name = First_Name;
                objContacts.Last_Name = Last_Name;
                objContacts.DOB = DOB;
                objContacts.Insert();
                
            }
    
            private void GetValuesFromModel()
            {
                Id = _Contacts.Id;
                First_Name = _Contacts.First_Name;
                Last_Name = _Contacts.Last_Name;
                DOB = _Contacts.DOB;
            }
            #endregion
    
            #region Commands
              public ICommand AddCommand
            {
                get
                {
                    if (_addCommand == null)
                    {
                        _addCommand = new WPFnMVVM.Common.RelayCommand(
                            param => this.AddContacts(),
                            param => true
                            );
                    }
                    return _addCommand;
                }
            }
            #endregion
    
        }
    }
