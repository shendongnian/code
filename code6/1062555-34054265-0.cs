    private PlotVm vm = new PlotVm();
        private void LayoutRoot_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            var window = new PlotWindow();
            ((IPlotModel)vm.Model)?.AttachPlotView(null);
            window.DataContext = vm;
            
            Debug.WriteLine(vm.Model.PlotView);
            window.ShowDialog();
            Debug.WriteLine(vm.Model.PlotView);
        }
