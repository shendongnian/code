    private delegate void MyClickEvent(object sender, EventArgs e); 
    public event MyClickEvent MyClick; 
    public void OnMyClickEvent(object sender, EventArgs e)
            {
                    if (MyClick != null)
                            MyClick(sender, e);//execute event
            } 
