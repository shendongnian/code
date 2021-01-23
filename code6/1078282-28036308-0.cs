    public void Click(...)
    {
        var control = sender as FrameWorkElement;
        if(control!= null)
        {
            var myVM = control.DataContext as MyViewModel;
            myVM.DoSomethingWithMyVM();
        }
    }
