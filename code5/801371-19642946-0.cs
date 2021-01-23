        private void LabelClick(object sender, EventArgs e)
        {
            string Path = ((Label)sender).Text ;
            System.Diagnostics.Process.Start(Path) ; 
         }
 
