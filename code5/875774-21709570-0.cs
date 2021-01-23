    using System;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class CustomResources : ResourceDictionary
        {
            public void MouseEnter(object sender, EventArgs e)
            {
                MessageBox.Show("Test");
            }
        }
    }
