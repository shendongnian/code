    public void MyButton_Click(object sender, EventArgs e)
    {
     Button b = (Button)sender;
     var myClass = b.DataContext;
     var MyClassId = myClass.ID;
     var MyPopupWindow = new MyPopupWindow(MyClassId);
     MyPopupWindow.Show();
    }
