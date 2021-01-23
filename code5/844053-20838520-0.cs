    public void CreateSensor(){
        Form SensorForm = new Form();
        SensorForm.Visible = false;
        SensorForm.FormBorderStyle = FormBorderStyle.None;
        SensorForm.WindowState = FormWindowState.Maximized; 
        SensorForm.MouseHover += new MouseEventHandler(SensorForm_Hover);
    }
    var MouseXList = new List<int>();   
    var MouseYList = new List<int>();   
 
    public void Analyse(){
        if(MouseXList.Count != MouseYList.Count){
            Console.WriteLine("An error occured when collection the mouse coordinates");
             return;      
        } 
        else{
            for(int i = 0; i < MouseXList.Count; ++i){
                Console.WriteLine("X: {0}, Y: {1}\n", MouseXList[i].ToString(), MouseYList[i].ToString());
            } 
        } 
    }
    private void SensorForm_Hover(object sender, MouseEventArgs e){
         MouseXList.Add(e.X);
         MouseYList.Add(e.Y);       
    }
