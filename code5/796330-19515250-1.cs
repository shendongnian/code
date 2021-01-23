    public partial class GroupsItems : UserControl
    {
       //properties and methods
    
        private string idd="";
        
        public string IDD
        {
        get{return idd;}
        set{
            idd=value; 
            textBox1.Text=idd;
            }
        }
    
       //other properties and methods
    }
