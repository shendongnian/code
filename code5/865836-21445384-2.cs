    string src = @"
    namespace x
    {
        using System.Windows;
        public class y
        {
            public void z(Label label1)
            {
                MessageBox.Show(""hello"");
                label1.Text = "Hello";
            }
        }
    }
    ";
