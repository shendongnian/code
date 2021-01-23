    public void test()
    {    
            Button[] buttons = new Button[] { button1, button2, button3, button4, };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].BackColor = Color.White;                
                buttons[i].Refresh();
                Thread.Sleep(100);
            }    
    }
