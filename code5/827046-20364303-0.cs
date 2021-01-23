    //adds deck class to Ideck interface
       public class Deck : IDeck
       {
          private List _list;
          //default deck call
          public Deck(List list)
          {
             _list = list;
             Reset();
          }
       }
