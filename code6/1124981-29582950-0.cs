    public void test()
     {
     for(int i=1; int i<5; i++)
      { 
         if(i==1)       
         button1.BackColor=Color.White;
         if(i==2) 
         button2.BackColor=Color.White;
         if(i==3)   
         button3.BackColor=Color.White;
         if(i==4) 
         button4.BackColor=Color.White;
         Application.DoEvents();
         Thread.Sleep(100);
       }
    }
