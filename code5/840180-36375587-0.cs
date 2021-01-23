        <Page x:Class="Login.Page2"
              xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
              xmlns:mc="http://schemas.openxmlformats.org/markup-      compatibility/2006" 
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
          mc:Ignorable="d" 
          d:DesignHeight="300" d:DesignWidth="300"
	      Title="Page2" Background="BlueViolet">
          <Grid>
          <TextBlock Height="23" HorizontalAlignment="Left" Margin="46,94,0,0"                         Name="textBlock1" Text="TextBlock" VerticalAlignment="Top" Width="198" />
           </Grid>
           </Page>
                        using System;
                        using System.Collections.Generic;
                        using System.Linq;
                        using System.Text;
                         using System.Windows;
                        using System.Windows.Documents;
                        using System.Windows.Input;
                         using System.Windows.Media;
                         using System.Windows.Media.Imaging;
                          using System.Windows.Navigation;
                          using System.Windows.Shapes;
                           namespace Login
                           {
                            /// <summary>
                             /// Interaction logic for Page1.xaml
                             /// </summary>
                                 public partial class Page1 : Page
                                {
                                 public Page1()
                                      {
                                  InitializeComponent();
                                     }
              private void buttoncheck_Click(object sender, RoutedEventArgs e)
                        {
            
                             Page2 p2 = new Page2();
                             p2.textBlock1.Text = txtnavigation.Text;
                            //txtnavigatevalue.Text = "";
                             NavigationService.Navigate(p2);
            
                                }
                                }
                               }
