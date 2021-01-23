    int Main()
        Cls s = new Cls();
        s.PropertyChanged += ShowMessage;
        s.print();
    }
    
    private void ShowMessage(object sender, PropertyChangedEventArgs args){
        MessageBox.Show("MyProperty changed!");
    }
