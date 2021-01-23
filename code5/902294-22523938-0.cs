    I have made it-
    MainWindow.xaml
    <Window x:Class="SerializeDeSerialize.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:Nikita="clr-namespace:SerializeDeSerialize"
            Title="MainWindow" Height="350" Width="525" Closed="Window_Closed_1" Loaded="Window_Loaded_1">
        <Window.DataContext>
            <Nikita:Movie></Nikita:Movie>
        </Window.DataContext>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
              
            </Grid.ColumnDefinitions>
    
            <Label Name="lblTitle" Content="Title:" Grid.Row="0" Grid.Column="0" Margin="10,25,63,10" HorizontalAlignment="Left" Width="164"></Label>
            <TextBox Grid.Row="0" Name="txtTitle" Grid.Column="1" Margin="10,25,63,10" Text="{Binding Title}"></TextBox>
            <Label Grid.Row="1" Name="lblRating" Content="Rating:" Grid.Column="0" Margin="10,25,63,10" HorizontalAlignment="Left" Width="164"></Label>
            <TextBox Grid.Row="1" Name="txtRating" Grid.Column="1" Margin="10,25,63,10" Text="{Binding Rating}"></TextBox>
            <Label Grid.Row="2" Name="lblReleaseDate" Content="Release Date:" Grid.Column="0"  Margin="10,25,63,10" HorizontalAlignment="Left" Width="164"></Label>
            <TextBox Grid.Row="2" Name="txtReleaseDate" Grid.Column="1" Margin="10,25,63,10" Text="{Binding ReleaseDate}"></TextBox>
            
                <Button Grid.Row="3" Content="Window1" Margin="66,36,69,10" Click="Button_Click_1"></Button>
            <Button Grid.Row="4" Content="Window2" Margin="66,36,69,10" Click="Button_Click_2"></Button>
            
        </Grid>
    </Window>
    
    MainWindow.xaml.cs
    
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml.Serialization;
    
    namespace SerializeDeSerialize
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            SerializeDeSerialize.Movie mv = new Movie();
            static Movie mm = new Movie();
            
            public MainWindow()
            {
                InitializeComponent();
                
                DataContext = mv;
    
            }
    
            private void Window_Closed_1(object sender, EventArgs e)
            {
                SerializeToXML(mv);
            }
    
            static public void SerializeToXML(Movie movie)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Movie));
                TextWriter textWriter = new StreamWriter(@"C:\Users\398780\Desktop\Nikita\movie.xml");
                serializer.Serialize(textWriter, movie);
                textWriter.Close();
            }
    
            private void Window_Loaded_1(object sender, RoutedEventArgs e)
            {
                mm=DeserializeFromXML();
                txtTitle.Text = mm.Title;
                txtRating.Text =Convert.ToString(mm.Rating);
                txtReleaseDate.Text = Convert.ToString(mm.ReleaseDate);
    
            }
    
            static Movie DeserializeFromXML()
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Movie));
                TextReader textReader = new StreamReader(@"C:\Users\398780\Desktop\Nikita\movie.xml");
                mm=(Movie)deserializer.Deserialize(textReader);
              
                textReader.Close();
    
                return mm;
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Window1 win1 = new Window1();
                win1.Show();
            }
    
            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                Window2 win2 = new Window2();
                win2.Show();
            }
        }
    }
    
    MVVM-movie.cs
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SerializeDeSerialize
    {
        public class Movie
        {
            private string _title;
            private int _rating;
            private DateTime _releaseDate;
    
            public Movie()
            {
            }
            public string Title
            {
                get { return _title; }
                set { _title = value; }
            }
    
            public int Rating
            {
                get { return _rating; }
                set { _rating = value; }
            }
    
            public DateTime ReleaseDate
            {
                get { return _releaseDate; }
                set { _releaseDate = value; }
            }
        }
    }
    
    Please check..it is same as you told or not?
