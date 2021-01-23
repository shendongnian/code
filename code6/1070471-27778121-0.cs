    int Sayi = Convert.ToInt32(TextBox1.Text);
        Button[] d1=new Button[Sayi];
        int Sy = 20;
        for (int k = 1; k <= Sayi; k++) {
            var b = new Button()
            b.ID = "Btn" + k.ToString();
            b.Width = 100;
            b.Height = 25;
            b.Text = k.ToString();
            b.Attributes.Add("style", "top:"+Sy+"; left:10 ;position:absolute");
            Sy += 20;
            d1[k] = b;
        }
