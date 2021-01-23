    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;
    using F=System.Windows.Forms;
    
    namespace SimpleForm {
    
    class Window1 : Window {
    
    	F.TextBox tb = new F.TextBox();
    	WindowsFormsHost host = new WindowsFormsHost();
    
    	public Window1() {
    		this.Width = 500;
    		this.Height = 500;
    		this.Title = "Title";
    		
    		host.Child = tb;
    
    		Button btn = new Button { Content = "Button" };
    		StackPanel panel = new StackPanel();
    		panel.Orientation = Orientation.Vertical;
    		panel.Children.Add(host);
    		panel.Children.Add(btn);
    		this.Content = panel;
    
    		btn.Click += delegate {
    			Window w2 = new Window { Width = 400, Height = 400 };
    			w2.Content = new TextBox();
    			w2.Show();
    		};
    	}
    
    	[STAThread]
    	static void Main(String[] args) {
    		F.Application.EnableVisualStyles();
    		F.Application.SetCompatibleTextRenderingDefault(false);
    		var w1 = new Window1();
    		System.Windows.Application app = new System.Windows.Application();
    		app.Run(w1);
    	}
    }
    }
