    [Serializable]
    public class TestData
    {
       private bool connect;
       private TcpClient connection;
       public string ServerName {get; set;}
      
       public bool ConnectToServer { 
           get { return this.connect; }
           set { 
              if (this.connect = value)
              {
                  this.connection = new TcpConnection(this.ServerName, 8080);
              }
           }
       }
    }
