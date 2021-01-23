    public class myclass {
           string id ;
           string title ;
           string content;
     }
     
     public class program {
            public void Main () {
                   List<myclass> objlist = new List<myclass> () ;
                   foreach (var value in objlist)  {
                           TextBox1.Text = value.id ;
                           TextBox2.Text= value.title;
                           TextBox3.Text= value.content ;
                    }
             }
      }
