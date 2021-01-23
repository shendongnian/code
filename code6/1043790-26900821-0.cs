    try:
    public partial class room2 : Form
    {
    Private int32 J=10;
    Private Int64 y = 1;
    Private Int64 t = 10;
    Private Int32 J = 10;
    Private Int32 t = 6 ;
    //This would mean J is a private variable that only members of this class can access
    //This is because it is declared at the top of the class (like you said, as you were advised to    do)
     //If you declare this in the constructor, other class elements cannot access it.
 
    
    //OTHER Variable code here then:
    public room2()
        {
            InitializeComponent();    
            Random rand1 = new Random();   
            Int32 Fight = rand1.Next(1, 11);
            label4.Text = Convert.ToString(10);
    
            if (Fight <= t)
            {
                label3.Text = Convert.ToString(J);
            }
            else
            {
                txtDialogBox.Text = ("No Fight in this room");
            }
        }
 
    private void Attack_Click(object sender, EventArgs e)
        {
            Random rand2 = new Random();
            Int32 J = 10;
            Int32 Attack = rand2.Next(1, 4);
            
            //opponents hp bar goes down by 1
            J --;
    
            label3.Text = Convert.ToString(J);
    
           // chance for your hp bar to go down
            if (Attack >= y)
            {
                label4.Text = Convert.ToString(t);
                t--;
            }
        }                  
        //Additionally, just for learning
        Public int32 J=10 
        //would mean anything, even things out of this class can access code in the class.
        
        Protected int32 J=10 
        //would mean anything that *Implements* this has access to this variable (something called an assembly)
