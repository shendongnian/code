            public FormParent parent { get; set; }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var source = (HwndSource)PresentationSource.FromDependencyObject(button);
            var host = (System.Windows.Forms.Integration.ElementHost)System.Windows.Forms.Control.FromChildHandle(source.Handle);
            var form = (System.Windows.Forms.Form)host.TopLevelControl;
            FormChild newMDIChild = new FormChild();
            newMDIChild.MdiParent = form;
            newMDIChild.Show();
