    /*In a WPF Window, content container being a Canvas, adding a new WFH with
    a `PicturBox()` on it. Then add it a DataGridView OVER this one, and then,
    some `Label` over it*/
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Content = new Canvas();
            System.Windows.Forms.Integration.WindowsFormsHost _wndHost = new System.Windows.Forms.Integration.WindowsFormsHost()
            {
                Margin = new Thickness(0, 0, 0, 0),
                Width = 200,
                Height = 200,
                Child = new System.Windows.Forms.PictureBox()
                {
                    BackgroundImage = new System.Drawing.Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\f.jpg"),
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
                }
            };
            ((System.Windows.Forms.PictureBox)_wndHost.Child).Controls.Add(new System.Windows.Forms.DataGridView()
            {
                Width = 170, Height = 70,
                ColumnCount = 2, RowCount = 2
            });
            ((System.Windows.Forms.PictureBox)_wndHost.Child).Controls.Add(new System.Windows.Forms.Integration.ElementHost()
            {
                Width = 70, Height = 15,
                Child = new TextBlock()
                {
                    Width = 10,
                    Height = 10,
                    Text = "First :O",
                    Foreground = Brushes.Red,
                    Background = Brushes.Transparent
                },
                BackColor = System.Drawing.Color.Transparent,
                Location = new System.Drawing.Point(10, 100)
            });
            ((System.Windows.Forms.PictureBox)_wndHost.Child).Controls.Add(new System.Windows.Forms.Integration.ElementHost()
            {
                Width = 70, Height = 15,
                Child = new TextBlock()
                {
                    Width = 10,
                    Height = 10,
                    Text = "Second :O",
                    Foreground = Brushes.Red,
                    Background = Brushes.Transparent
                },
                BackColor = System.Drawing.Color.Transparent,
                Location = new System.Drawing.Point(10, 150)
            });
            ((Canvas)Content).Children.Add(_wndHost);
        }
    }
