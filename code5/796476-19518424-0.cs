     public partial class MainWindow : Window
    {
        List<List<string>> Buttons;
        public MainWindow()
        {
            InitializeComponent();
            Buttons = new List<List<string>>();
            /////////////////////////////////////////
            List<string> lst1 = new List<string>();
            lst1.Add("main1");
            lst1.Add("a1");
            lst1.Add("a2");
            lst1.Add("a3");
            lst1.Add("a4");
            Buttons.Add(lst1);
            /////////////////////////////////////////
            List<string> lst2 = new List<string>();
            lst2.Add("main2");
            lst2.Add("b1");
            lst2.Add("b2");
            lst2.Add("b3");
            lst2.Add("b4");
            Buttons.Add(lst2);
            /////////////////////////////////////////
            List<string> lst3 = new List<string>();
            lst3.Add("main3");
            lst3.Add("c1");
            lst3.Add("c2");
            lst3.Add("c3");
            lst3.Add("c4");
            Buttons.Add(lst3);
            for (int i = 0; i < Buttons.Count; i++)
            {
                Button newBtn = new Button();
                newBtn.Content = Buttons[i][0];
                newBtn.Name = "Button" + i.ToString();
                newBtn.Height = 23;
                stackPanel1.Children.Add(newBtn);
                newBtn.Click += new RoutedEventHandler(newBtn_Click);
                Expander expader = new Expander();
                StackPanel newStck = new StackPanel();
                for (int j = 1; j < Buttons[i].Count; j++)
                {
                    Button newBtnIn = new Button();
                    newBtnIn.Content = Buttons[i][j];
                    newBtnIn.Name = "Button" + j.ToString();
                    newBtnIn.Height = 23;
                    newBtnIn.Width = 100;
                    newBtn.Tag = expader;
                    newBtn.Click+=newBtn_Click;
                    newStck.Children.Add(newBtnIn);
                }
                expader.Content = newStck;
                stackPanel1.Children.Add(expader);
            }
        }
        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            
            if (b == null)
                return;
            Expander ex = b.Tag as Expander;
            if (ex == null)
                return;
            ex.IsExpanded = !ex.IsExpanded;
        }
    }
