        private void button1_Click(object sender, EventArgs e)
        {
            string pkgLocation;
            Package pkg;
            Microsoft.SqlServer.Dts.Runtime.Application app;
            DTSExecResult pkgResults;
            MyEventListener eventListener = new MyEventListener();
            pkgLocation =
              @"C:\FilePath.dtsx";
             
            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkg = app.LoadPackage(pkgLocation, eventListener);
            pkgResults = pkg.Execute(null, null, eventListener, null, null);
        
            MessageBox.Show(pkgResults.ToString());
            
        }
        class MyEventListener : DefaultEvents
        {
            public override bool OnError(DtsObject source, int errorCode, string subComponent,
              string description, string helpFile, int helpContext, string idofInterfaceWithError)
            {
                // Add application-specific diagnostics here.
                MessageBox.Show("Error in " + "/t" + source + "/t" + subComponent + "/t" + description);
                return false;
            }
        }
