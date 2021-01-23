    [XmlInclude(typeof(Audi))]
    [XmlInclude(typeof(Volvo))]
    public class Car {
      private string m_Name = "Car";
      public virtual string Name {
        get { return m_Name; }
        set { m_Name = value; }
      }
    }
    public class Audi : Car {
      private string m_Name = "Audi";
 
      public override string Name {
        get { return m_Name; }
        set { m_Name = value; }
      }
    }
    public class Volvo : Car {
      private string m_Name = "Volvo";
      public override string Name {
        get { return m_Name; }
        set { m_Name = value; }
      }
    }
