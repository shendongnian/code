     DateTime time = new DateTime();//time of first click
     int counter = 0;
    void button_click(object sender, EventArgs e)
    {
        if(counter == 0)
        {time = DateTime.Now}
        else if(counter == 5)
        {
             if( DateTime.Now.Subtract(time).Duration().Seconds <= 10)
             {/*Do some cool stuff*/}
             else
             {counter = -1;}
        }
        counter++;
    }
