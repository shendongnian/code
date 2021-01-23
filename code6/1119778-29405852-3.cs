    using System;
    using System.IO;
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
              if (format == "FileGroupDescriptor")
              {
                Microsoft.Office.Interop.Outlook.Application OL = new Microsoft.Office.Interop.Outlook.Application();
                sb.AppendLine("##################################################");
                for (int i = 1; i <= OL.ActiveExplorer().Selection.Count; i++)
                {
                  Object temp = OL.ActiveExplorer().Selection[i];
                  if (temp is Microsoft.Office.Interop.Outlook.MailItem)
                  {
                    Microsoft.Office.Interop.Outlook.MailItem mailitem = (temp as Microsoft.Office.Interop.Outlook.MailItem);
                    int n=1;
                    sb.AppendLine("Mail " + i + ": " + mailitem.Subject);
                    foreach (Microsoft.Office.Interop.Outlook.Attachment attach in mailitem.Attachments)
                    {
                      sb.AppendLine("File " + i + "."+n+": " + attach.FileName);
                      sb.AppendLine("Size " + i + "."+n+": " + attach.Size);
                      sb.AppendLine("For save using attach.SaveAsFile");
                      ++n;
                    }
                  }
                }
                sb.AppendLine("##################################################");
              }
              else
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
