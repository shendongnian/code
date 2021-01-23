     public Form1()
            {
            
                InitializeComponent();
    
                this.components = new System.ComponentModel.Container();
                this.contextMenu1 = new System.Windows.Forms.ContextMenu();
                this.menuItem1 = new System.Windows.Forms.MenuItem();
    
                // Initialize contextMenu1 
                this.contextMenu1.MenuItems.AddRange(
                            new System.Windows.Forms.MenuItem[] { this.menuItem1 });
    
                // Initialize menuItem1 
                this.menuItem1.Index = 0;
                this.menuItem1.Text = "E&xit";
                this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
    
                // Set up how the form should be displayed. 
                this.ClientSize = new System.Drawing.Size(292, 266);
                this.Text = "Notify Icon Example";
    
                // Create the NotifyIcon. 
                this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
    
                // The Icon property sets the icon that will appear 
                // in the systray for this application.
                notifyIcon1.Icon = new Icon("Icon.ico");
    
                // The ContextMenu property sets the menu that will 
                // appear when the systray icon is right clicked.
                notifyIcon1.ContextMenu = this.contextMenu1;
    
                // The Text property sets the text that will be displayed, 
                // in a tooltip, when the mouse hovers over the systray icon.
                notifyIcon1.Text = "Form1 (NotifyIcon example)";
                notifyIcon1.Visible = true;
    
                // Handle the DoubleClick event to activate the form.
                notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
    
            }
