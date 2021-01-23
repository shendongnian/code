    String text = TextBox.Text;
    try{
        long value = long.parse(text.trim());
        if(value > 0 && value < 101){
           //do something here
        }
        else{
           //Do something else
        }
    }
    catch(Exception e){
       Messagebox.Show("Please check you input and try again");
    }
