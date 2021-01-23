    public partial class MainWindow : Window
    {
        private bool paraOneAdded = false;
        private bool paraTwoAdded = false;
        private bool paraThreeAdded = false;
        private bool paraFourAdded = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!paraOneAdded)
            {
                Paragraph para = new Paragraph();
                para.Name = "temp1";
                para.Inlines.Add(new Bold(new Run("Template 1.")));
                para.Inlines.Add(new LineBreak());
                para.Inlines.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean Condimentum, orci eu placerat interdum, odio lacus faucibus ex, et viverra justo sem nec augue.");
                flowDoc.Blocks.Add(para);
                paraOneAdded = true;
            }
            else
            {
                var myPara = flowDoc.Blocks.FirstOrDefault(p => p.Name == "temp1");
                if (myPara != null)
                {
                    flowDoc.Blocks.Remove(myPara);
                    paraOneAdded = false;
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!paraTwoAdded)
            {
                Paragraph para = new Paragraph();
                para.Name = "temp2";
                para.Inlines.Add(new Bold(new Run("Template 2.")));
                para.Inlines.Add(new LineBreak());
                para.Inlines.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean Condimentum, orci eu placerat interdum, odio lacus faucibus ex, et viverra justo sem nec augue.");
                flowDoc.Blocks.Add(para);
                paraTwoAdded = true;
            }
            else
            {
                var myPara = flowDoc.Blocks.FirstOrDefault(p => p.Name == "temp2");
                if (myPara != null)
                {
                    flowDoc.Blocks.Remove(myPara);
                    paraTwoAdded = false;
                }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!paraThreeAdded)
            {
                Paragraph para = new Paragraph();
                para.Name = "temp3";
                para.Inlines.Add(new Bold(new Run("Template 3.")));
                para.Inlines.Add(new LineBreak());
                para.Inlines.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean Condimentum, orci eu placerat interdum, odio lacus faucibus ex, et viverra justo sem nec augue.");
                flowDoc.Blocks.Add(para);
                paraThreeAdded = true;
            }
            else
            {
                var myPara = flowDoc.Blocks.FirstOrDefault(p => p.Name == "temp3");
                if (myPara != null)
                {
                    flowDoc.Blocks.Remove(myPara);
                    paraThreeAdded = false;
                }
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!paraFourAdded)
            {
                Paragraph para = new Paragraph();
                para.Name = "temp4";
                para.Inlines.Add(new Bold(new Run("Template 4.")));
                para.Inlines.Add(new LineBreak());
                para.Inlines.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean Condimentum, orci eu placerat interdum, odio lacus faucibus ex, et viverra justo sem nec augue.");
                flowDoc.Blocks.Add(para);
                paraFourAdded = true;
            }
            else
            {
                var myPara = flowDoc.Blocks.FirstOrDefault(p => p.Name == "temp4");
                if (myPara != null)
                {
                    flowDoc.Blocks.Remove(myPara);
                    paraFourAdded = false;
                }
            }
        }
    }
