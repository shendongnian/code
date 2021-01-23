     private void Employee_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var  empCloned = DeepClone<Employee>(this); 
            History.Add(empCloned);
            //throw new NotImplementedException();
        }
