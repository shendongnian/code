    //MainPage.xaml.cs
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using Windows.Security.Credentials;
    namespace App1
    {
    public sealed partial class MainPage : Page
    {
        PasswordVault vault = new PasswordVault();
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            
            //Initialize Credential data
            try
            {
                var alldata = vault.FindAllByResource("My List");
                foreach (PasswordCredential data in alldata)
                {
                    vault.Remove(data);
                }
            }
            catch { }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Certificate for Input data
            PasswordCredential credential = null;
            try
            {
                credential = vault.Retrieve("My List", Username.Text);
                if(credential.Password==password.Password)             
                {
                    Status.Text = "Status : Succeed in Certificating";
                }
                else
                {
                    Status.Text = "Status : Failed to Certification";
                }
            }
            catch { Status.Text = "Status : Failed to Certification"; }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Registar on Input data
            try
            {
                vault.Add(new PasswordCredential("My List", Username.Text, password.Password));
                Status.Text = "Status : Succeed in Registering";
            }
            catch
            {
                Status.Text = "Status : Failed to Register";
            }
        }
    }
    }
