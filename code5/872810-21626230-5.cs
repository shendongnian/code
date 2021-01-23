        namespace WpfApplication
        {
           using System;
           using System.Collections.Generic;
           using System.ComponentModel;
           using System.Linq;
           using System.Text;
           using System.Windows.Input;
           
           /// <summary>
           /// TODO: Update summary.
           /// </summary>
           public class MainWindowViewModel : INotifyPropertyChanged
           {    
              #region Implementation of INotifyPropertyChanged
              
              /// <summary>
              /// Occurs when a property value changes.
              /// </summary>
              public event PropertyChangedEventHandler PropertyChanged;
    
              /// <summary>
              /// Signal that the property value with the specified name has changed.
              /// </summary>
              /// <param name="propertyName">The name of the changed property.</param>
              protected virtual void OnPropertyChanged(string propertyName)
              {
                 if (this.PropertyChanged != null)
                 {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                 }
              }
                 
              #endregion Implementation of INotifyPropertyChanged
    
              #region Backing Fields
    
              /// <summary>
              /// Gets or sets the value of Name.
              /// </summary>
              private string name;
    
              /// <summary>
              /// Gets or sets the value of Password.
              /// </summary>
              private string password;
              
              /// <summary>
              /// Gets or sets the value of LoginCommand.
              /// </summary>
              private LoginCommand loginCommand;
              
              #endregion Backing Fields
              
              #region Constructor
              
              /// <summary>
              /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
              /// </summary>
              public MainWindowViewModel()
              {
                 this.loginCommand = new LoginCommand();
              }
    
              #endregion Constructor
              
              #region Properties
              
              /// <summary>
              /// Gets or sets the name of the user.
              /// </summary>
              public string Name
              {
                 get
                 {
                    return this.name;
                 }
              
                 set
                 {
                    if (this.name == value)
                    {
                       return;
                    }
    
                    this.name = value;
                    this.OnPropertyChanged("Name");
                 }
              }
              
              /// <summary>
              /// Gets or sets the user password.
              /// </summary>
              public string Password
              {
                 get
                 {
                    return this.password;
                 }
    
                 set
                 {
                    if (this.password == value)
                    {
                       return;
                    }
                    
                    this.password = value;
                    this.OnPropertyChanged("Password");
                 }
              }
    
              /// <summary>
              /// Gets or sets the command object that handles the login.
              /// </summary>
              public ICommand LoginCommand
              {
                 get
                 {
                    return this.loginCommand;
                 }
              
                 set
                 {
                    if (this.loginCommand == value)
                    {
                       return;
                    }
                 
                    this.loginCommand = (LoginCommand)value;
                    this.OnPropertyChanged("LoginCommand");
                 }
              }
              
              #endregion Properties
           }
        }
