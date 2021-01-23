    private void HandleScroll(){
        if (mypanel.HorizontalScroll.Value > 500) {
            lbl1.Text = "A";
        }
        else if (mypanel.HorizontalScroll.Value < 300) {
            lbl1.Text = "B";
        }
    }
    //place this code in your form constructor after InitializeComponent()
    panel1.Scroll += (s,e) => {
       HandleScroll();
    };
    panel1.MouseWheel += (s,e) => {  
       HandleScroll();
    };
