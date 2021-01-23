    public class USER
    {
       // changed to public getters so externally can be accessed
       // for read-only, but write access for USER instance or derived class (PLAYER)
       // QUESTIONABLE on public accessor on password
       public string name { get; protected set; }
       public string surname { get; protected set; }
       public string ID { get; protected set; }
       public string password { get; protected set; }
       public string IP { get; protected set; }
       
       WALLET wallet;
       bool login;
       datetime lastAccess;
       TcpClient socket;    
       // make this too protected AND available to player AND any others that make sense above
       protected Thread receiveMessages; //this receive message for meneage the game
       ...*other 30 proprieties*
    
       public USER(string nm, string sur, string _id, string pw)
       {
          name = nm;
          surname = sur;
          ID = _id;
          password = pw;
       
          InitUserVars();
       }
       
       private InitUserVars()
       {
          *inizialize all variables*
       }
       
    }
    
    public class PLAYER : USER
    {
       // removed the Thread receiveMessages;
       // as it is avail on parent class  USER
       ...*other proprieties*
    
       // slightly different option, instead, call the "THIS" version of constructor
       public PLAYER(USER ui) : this(ui.name, ui.surname, ui.ID, ui.password )
       {  }
    
       // Now, pass same initializing parms to the USER base class so that all still runs the same.  
       public PLAYER(string nm, string sur, string _id, string pw) : base(nm, sur, _id, pw)
       {
          // by calling the "base" above, all default behaviors are handled first
          
          // Now, we can do whatever else specific to the PLAYER
          InitPlayerVars()
       }
    
    
       private InitPlayerVars()
       {
          *inizialize variables associated with PLAYER that is NOT part of USER baseclass*
       }
    }
