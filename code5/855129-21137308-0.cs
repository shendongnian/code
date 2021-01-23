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
    using System.ComponentModel;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            BackgroundWorker bckg =  new BackgroundWorker();
            private List<string> allXmlFiles;   
            public MainWindow()
            {
                InitializeComponent();
    
                bckg.DoWork += new DoWorkEventHandler(bckg_DoWork);
                bckg.ProgressChanged += new ProgressChangedEventHandler(bckg_ProgressChanged);
                bckg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckg_RunWorkerCompleted);
                 
    
            }
    
            void bckg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Error!=null)
                {
                    textbox.Text += String.Format("\nCannot process file {0}", filepath);
                }
            }
    
            void bckg_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                //here you can update your textblox 
    
                Dispatcher.Invoke(() =>
                    {
                        textbox.Text = e.UserState.ToString();
                    });
    
            }
    
            void bckg_DoWork(object sender, DoWorkEventArgs e)
            {
                allXmlFiles = ProcessDirectory(selectedDir);
                if (allXmlFiles.Count > 0)
                {
                   
                    bckg.ReportProgress("here in percentage", "\nProcessing files...");
                    foreach (string filepath in allXmlFiles)
                    {
                        try
                        {
                            ParseFile(filepath);
                        }
                        catch
                        {
                            throw;  
                        }
                    }
                }
                
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
               
                textbox.Text += String.Format("\n{0} files will be processed", allXmlFiles.Count);
                bckg.RunWorkerAsync();
            }
        }
    }
