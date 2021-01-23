    <Window x:Class="WpfApplication4.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
    		<ContentControl x:Name="Content"></ContentControl>
        </Grid>
    </Window>
    using System;
    using System.Collections.Generic;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication4
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			Loaded += MainWindow_Loaded;
    		}
    
    		private Button m_Button1;
    		private Button m_Button2;
    
    		void MainWindow_Loaded(object sender, RoutedEventArgs e)
    		{
    			Loaded -= MainWindow_Loaded;
    
    			m_Button1 = new Button { Content = "Button1" };
    			m_Button2 = new Button { Content = "Button2" };
    
    			m_Button1.Click += button1_Click;
    			m_Button2.Click += m_Button2_Click;
    
    			Content.Content = m_Button1;
    		}
    
    		void m_Button2_Click(object sender, RoutedEventArgs e)
    		{
    			Content.Content = m_Button1;
    		}
    
    		void button1_Click(object sender, RoutedEventArgs e)
    		{
    			Content.Content = m_Button2;
    		}
    	}
    }
