    using System;
    using System.IO;
    using System.Windows;
    
    namespace WpfWb
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			this.Loaded += (s, e) =>
    			{
    				var textHtml = "<html><body><b>Hello</b>, World!</body></html>";
    
    				string tempPath = System.IO.Path.GetTempPath();//get TEMP folder location
    				tempPath += "htmldev\\";
    				if (!Directory.Exists(tempPath))
    				{
    					Directory.CreateDirectory(tempPath);
    				}
    				tempPath += "current.html";
    				if (File.Exists(tempPath))
    				{
    					File.Delete(tempPath);//delete the old file
    				}
    				StreamWriter sr = new StreamWriter(tempPath);
    				sr.WriteLine(textHtml);//write the HTML code in the temporary file
    				sr.Close();
    
    				previewBrowser.Source = new Uri(tempPath);//When I comment this line my program compiles successfully, and the file is created.
    			};
    		}
    	}
    }
