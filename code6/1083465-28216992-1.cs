                public class Kontakter {
                 public bool override Equals(Object obj) {    
                           var castedObj  = (Kontakter)obj;
                           return castedObj.PropertyOne == this.ProperyOne &&  castedObj.Property2 == this.Property2
                       }
                 }
