    public void ChangeColor()
    {
        Button[] arr = new Button[2];
        arr[0] = btn1;
        arr[1] = btn2;
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].BackColor = System.Drawing.Color.Red;         
        }
    }
