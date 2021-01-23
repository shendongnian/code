    private void genericButton_event(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage =   new Bitmap(System.Reflection.Assembly.GetEntryAssembly(). 
                GetManifestResourceStream("MyProject.Resources" + btn.Name +".png"));       
        
        }
