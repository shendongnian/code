    class CarInfo
    {
       // here your properties of the car
    }
    // here you have your listview with accumulated car data
    class CarDisplay : Form    
    {
    
        private List<CarInfo> _carList = new List<CarInfo>(); 
        // here you popup the data entry form and wire to the saving callback
        void buttonShowDataForm_Click (sender, e)
        {
            // yes - this is best way to show forms because it will dispose them too
            using (f = new formDataCollect(CarInfoSubmitCallback))
            {
                f.ShowModal();
            }
        }
        // here you have your view populated and any operations that you want to add a car
        void CarInfoSubmitCallback (CarInfo info)
        {
            _carList.Add(info);
            // optionally here you can do your UI stuff or save to DB, whatever
        }
        
    }
    // this is your car data entry form
    class CarDataEntry : Form
    {
        
        private Action<CarInfo> _addCarCallback;
        // your constructor passes method that will be called later when user's data is to be saved. In your case, this method will be executed on the form that has your list
        public CarDataEntry (Action<CarInfo> callBack) 
        {
            _addCarCallback = callBack;
        }
        // here you have your view
        void buttonAddCar_Click (sender, e)
        {
             var ci = new CarInfo();
             ci.Name = txtName.Text;
             // and so on with properties
             _callBack(ci);
        }
       
    }
