        public class Class1
        {
            public string String1 { get; set; }
            public string String2 { get; set; }
            public string String3 { get; set; }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
                ListBox1.Items.Add((new Class1()
                {
                    String1 = "Apple",
                    String2 = "Car",
                    String3 = "Tree"
                }));
        }
