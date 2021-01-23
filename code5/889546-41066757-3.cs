     class WebService{
      public static List<user> UserLoglist = new List<user>();//list of logged in users
    
     [WebMethod(Description = "Per session Hit Counter", EnableSession = true)]
    public void  ClnUpdateFlag(string un)//gets called via ajax
    {//Updates the flags i
        //update users status
        WebService.UserLoglist.Find(y => y.username == un).isLoggedin = true;
    }
        }
    public class user
    {
        public string username;
        public System.Timers.Timer timScheduledTask = new System.Timers.Timer();
        public bool isLoggedin = true;
        public  user(string puser)
        {
            username = puser;
            
            setimer(); //set server side timer
        }
        void Timer1_Tick(object sender, EventArgs e)
       {
       
         ...
      if (isLoggedin)// window is still open
              isLoggedin = false;
       else// user closed the window
          {
             ...
              
              WebService.UserLoglist.RemoveAll(x => x.username == username);// instance is deleted here
              
       ...
             
          } 
          }
        }
        void setimer()
        {
            timScheduledTask.Interval = 3000;
            timScheduledTask.Enabled = true;
             timScheduledTask.Start(); 
            timScheduledTask.Elapsed +=
            new System.Timers.ElapsedEventHandler(Timer1_Tick);
        }
     }
}
        class login{
 
       ...
        public void Logon_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(UserEmail.Text, UserPass.Text)){
            ...
             WebService.UserLoglist.Add(new user(UserEmail.Text));// instance of the user is instantiated here
            }
       ...
       }
     }
