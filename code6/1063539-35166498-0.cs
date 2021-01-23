    using System;
    using System.Collections.Generic;
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
    using System.Windows.Media.Animation;
    
    namespace WpfApplication4
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<Point> points = null;
            List<Line> lines = null;
            List<Storyboard> boards = null;
    
            public MainWindow()
            {
                InitializeComponent();
    
                points = new List<Point>();
                lines = new List<Line>();
                boards = new List<Storyboard>();
    
                points.Add(new Point(0, 0));
                points.Add(new Point(200, 200));
                points.Add(new Point(200, 0));
                points.Add(new Point(0, 0));
                points.Add(new Point(0, 200));
                points.Add(new Point(200, 200));
                points.Add(new Point(300, 200));
    
                SetupLines();
                DrawLines();
            }
    
            public void SetupLines()
            {
                int speed = 1;
                lines.Add(new Line());
                boards.Add(new Storyboard());
    
                for (int i = 0; i < points.Count - 1; i++ )
                {
                    lines.Add(new Line());
                    boards.Add(new Storyboard());
    
                    canvas1.Children.Add(lines[i]);
                    lines[i].Stroke = Brushes.Red;
                    lines[i].StrokeThickness = 7;
    
                    lines[i].X1 = points[i].X;
                    lines[i].Y1 = points[i].Y;
                    lines[i].X2 = points[i].X;
                    lines[i].Y2 = points[i].Y;
    
                    DoubleAnimation da = new DoubleAnimation(points[i].X, points[i+1].X, new Duration(new TimeSpan(0, 0, speed)));
                    DoubleAnimation da1 = new DoubleAnimation(points[i].Y, points[i+1].Y, new Duration(new TimeSpan(0, 0, speed)));
                    
                    Storyboard.SetTargetProperty(da, new PropertyPath("(Line.X2)"));
                    Storyboard.SetTargetProperty(da1, new PropertyPath("(Line.Y2)"));
    
                    boards[i].Children.Add(da);
                    boards[i].Children.Add(da1);
    
                    da.BeginTime = new TimeSpan(0, 0, i * speed);
                    da1.BeginTime = new TimeSpan(0, 0, i * speed);
    
                    lines.Add(new Line());
                    boards.Add(new Storyboard());
                } 
            }
    
            public void DrawLines()
            {
                for (int i = 0; i < boards.Count - 1; i++)
                {
                    lines[i].BeginStoryboard(boards[i]);
                }
            }
        }
    }
