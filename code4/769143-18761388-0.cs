    class MyPage:Page{
        TextBox TextBoxName {get;set;}
    
        public void CreateForm(string passengerType, int passengerCount)
        {
            TextBoxName = new TextBox();
            this.Controls.Add(TextBoxName);
        }
    
    }
