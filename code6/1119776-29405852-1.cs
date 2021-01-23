    using System;
    using System.Text;
    using System.Windows;
    namespace WpfApplication1
    {
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
        }
        private void ContainerDrop(object sender, DragEventArgs e)
        {
          f_DropText.Text = "";
          StringBuilder sb = new StringBuilder();
          foreach (string format in e.Data.GetFormats())
          {
            sb.AppendLine("Format:" + format);
            try
            {
              object data = e.Data.GetData(format);
              sb.AppendLine("Type:" + (data == null ? "[null]" : data.GetType().ToString()));
              sb.AppendLine("Data:" + data.ToString());
            }
            catch (Exception ex)
            {
              sb.AppendLine("!!CRASH!! " + ex.Message);
            }
            sb.AppendLine("=====================================================");
          }
          f_DropText.Text = sb.ToString();
        }
        private void ContainerDragOver(object sender, DragEventArgs e)
        {
          e.Effects = DragDropEffects.Copy;
          e.Handled = true;
        }
      }
    }
